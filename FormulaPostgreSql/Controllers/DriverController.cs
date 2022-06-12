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
    public class DriverController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DriverController(IUnitOfWork unitOfWork)
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
            DriverVM driverVM = new()
            {
                Driver = new(),
                CountryList = _unitOfWork.Country.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Countryname,
                    Value = i.Id.ToString()
                }),
                TeamList = _unitOfWork.Team.GetAll().Select(i => new SelectListItem
                {
                    Text = i.TeamName,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                //create
                return View(driverVM);
            }
            else
            {
                //edit
                driverVM.Driver = _unitOfWork.Driver.GetFirstOrDefault(u => u.Id == id);
                return View(driverVM);
            }


        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(DriverVM obj)
        {

            if (ModelState.IsValid)
            {
                if(obj.Driver.Id == 0)
                {
                    _unitOfWork.Driver.Add(obj.Driver);
                    TempData["success"] = "Driver Created successfully";
                }
                else
                {
                    _unitOfWork.Driver.Update(obj.Driver);
                    TempData["success"] = "Driver Updated successfully";
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
            var teamList = _unitOfWork.Driver.GetAll(includeProps: "Country,Team");
            return Json(new { data = teamList });
        }

        ////POST Delete
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Driver.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.Driver.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Driver Deleted successfully." });
            return RedirectToAction("Index");
        }
        #endregion
    }
}
