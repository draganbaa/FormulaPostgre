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
    public class QualifyingResultController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QualifyingResultController(IUnitOfWork unitOfWork)
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
            QualifyingResultVM resultVM = new()
            {
                QualifyingResult = new(),
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
                return View(resultVM);
            }
            else
            {
                //edit
                resultVM.QualifyingResult = _unitOfWork.QualifyingResult.GetFirstOrDefault(u => u.Id == id);
                return View(resultVM);
            }


        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(QualifyingResultVM obj)
        {

            if (ModelState.IsValid)
            {
                if(obj.QualifyingResult.Id == 0)
                {
                    _unitOfWork.QualifyingResult.Add(obj.QualifyingResult);
                    TempData["success"] = "Qualifying Result Created successfully";
                }
                else
                {
                    _unitOfWork.QualifyingResult.Update(obj.QualifyingResult);
                    TempData["success"] = "Qualifying Result Updated successfully";
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
            var resultList = _unitOfWork.QualifyingResult.GetAll(includeProps: "Driver,Race");
            return Json(new { data = resultList });
        }

        ////POST Delete
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.QualifyingResult.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.QualifyingResult.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Qualifying Result Deleted successfully." });
            return RedirectToAction("Index");
        }
        #endregion
    }
}
