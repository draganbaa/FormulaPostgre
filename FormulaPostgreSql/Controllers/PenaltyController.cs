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
    public class PenaltyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PenaltyController(IUnitOfWork unitOfWork)
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
            PenaltyVM penaltyVM = new()
            {
                Penalty = new(),
                RaceList = _unitOfWork.Race.GetAll().Select(i => new SelectListItem
                {
                    Text = i.RaceName,
                    Value = i.Id.ToString()
                }),
                DriverList = _unitOfWork.Driver.GetAll().Select(i => new SelectListItem
                {
                    Text = i.DriverName,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                //create
                return View(penaltyVM);
            }
            else
            {
                //edit
                penaltyVM.Penalty = _unitOfWork.Penalty.GetFirstOrDefault(u => u.Id == id);
                return View(penaltyVM);
            }


        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PenaltyVM obj)
        {

            if (ModelState.IsValid)
            {
                if(obj.Penalty.Id == 0)
                {
                    _unitOfWork.Penalty.Add(obj.Penalty);
                    TempData["success"] = "Penalty Created successfully";
                }
                else
                {
                    _unitOfWork.Penalty.Update(obj.Penalty);
                    TempData["success"] = "Penalty Updated successfully";
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
            var penaltyList = _unitOfWork.Penalty.GetAll(includeProps: "Driver,Race");
            return Json(new { data = penaltyList });
        }

        ////POST Delete
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Penalty.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.Penalty.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Penalty Deleted successfully." });
            return RedirectToAction("Index");
        }
        #endregion
    }
}
