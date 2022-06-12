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
    public class RaceResultController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RaceResultController(IUnitOfWork unitOfWork)
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
            RaceResultsVM raceResultsVM = new()
            {
                RaceResult = new(),
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
                return View(raceResultsVM);
            }
            else
            {
                //edit
                raceResultsVM.RaceResult = _unitOfWork.RaceResult.GetFirstOrDefault(u => u.Id == id);
                return View(raceResultsVM);
            }


        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(RaceResultsVM obj)
        {

            if (ModelState.IsValid)
            {
                if(obj.RaceResult.Id == 0)
                {
                    _unitOfWork.RaceResult.Add(obj.RaceResult);
                    TempData["success"] = "Race Result Created successfully";
                }
                else
                {
                    _unitOfWork.RaceResult.Update(obj.RaceResult);
                    TempData["success"] = "Race Result Updated successfully";
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
            var raceResultList = _unitOfWork.RaceResult.GetAll(includeProps: "Driver,Race");
            return Json(new { data = raceResultList });
        }

        ////POST Delete
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.RaceResult.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.RaceResult.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Race Result Deleted successfully." });
            return RedirectToAction("Index");
        }
        #endregion
    }
}
