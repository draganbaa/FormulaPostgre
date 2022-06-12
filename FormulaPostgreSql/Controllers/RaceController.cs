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
    public class RaceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RaceController(IUnitOfWork unitOfWork)
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
            RaceVM raceVM = new()
            {
                Race = new(),
                TrackList = _unitOfWork.TrackInfo.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Trackname,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                //create
                return View(raceVM);
            }
            else
            {
                //edit
                raceVM.Race = _unitOfWork.Race.GetFirstOrDefault(u => u.Id == id);
                return View(raceVM);
            }


        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(RaceVM obj)
        {

            if (ModelState.IsValid)
            {
                if(obj.Race.Id == 0)
                {
                    _unitOfWork.Race.Add(obj.Race);
                    TempData["success"] = "Race Created successfully";
                }
                else
                {
                    _unitOfWork.Race.Update(obj.Race);
                    TempData["success"] = "Race Updated successfully";
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
            var raceList = _unitOfWork.Race.GetAll(includeProps: "TrackInfo");
            return Json(new { data = raceList });
        }

        ////POST Delete
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Race.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.Race.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Race Deleted successfully." });
            return RedirectToAction("Index");
        }
        #endregion
    }
}
