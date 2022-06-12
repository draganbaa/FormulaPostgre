using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormulaPostgreSql.Data;
using FormulaPostgreSql.Models;
using FormulaPostgreSql.DataAccess.Repository.IRepository;
using FormulaPostgreSql.Models.ViewModels;

namespace FormulaPostgreSql.Controllers
{
    public class TeamController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            return View();
        }

        //GET Upsert
        public IActionResult Upsert(int? id)
        {
            TeamVM teamVM = new()
            {
                Team = new(),
                CountryList = _unitOfWork.Country.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Countryname,
                    Value = i.Id.ToString()
                }),
                LocationList = _unitOfWork.LocationInfo.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Locationname,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                //create
                return View(teamVM);
            }
            else
            {
                //edit
                teamVM.Team = _unitOfWork.Team.GetFirstOrDefault(u => u.Id == id);
                return View(teamVM);
            }


        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TeamVM obj)
        {

            if (ModelState.IsValid)
            {
                if(obj.Team.Id == 0)
                {
                    _unitOfWork.Team.Add(obj.Team);
                    TempData["success"] = "Team Created successfully";
                }
                else
                {
                    _unitOfWork.Team.Update(obj.Team);
                    TempData["success"] = "Location Updated successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var teamList = _unitOfWork.Team.GetAll(includeProps: "Country,LocationInfo");
            return Json(new { data = teamList });
        }

        ////POST Delete
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Team.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.Team.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Team Deleted successfully." });
            return RedirectToAction("Index");
        }
        #endregion
    }
}
