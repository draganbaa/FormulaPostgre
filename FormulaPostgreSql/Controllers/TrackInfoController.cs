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
    public class TrackInfoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrackInfoController(IUnitOfWork unitOfWork)
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
            TrackVM trackVM = new()
            {
                TrackInfo = new(),
                LocationList = _unitOfWork.LocationInfo.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Locationname,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                //create
                return View(trackVM);
            }
            else
            {
                //edit
                trackVM.TrackInfo = _unitOfWork.TrackInfo.GetFirstOrDefault(u => u.Id == id);
                return View(trackVM);
            }


        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TrackVM obj)
        {

            if (ModelState.IsValid)
            {
                if(obj.TrackInfo.Id == 0)
                {
                    _unitOfWork.TrackInfo.Add(obj.TrackInfo);
                    TempData["success"] = "Track Created successfully";
                }
                else
                {
                    _unitOfWork.TrackInfo.Update(obj.TrackInfo);
                    TempData["success"] = "Track Updated successfully";
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
            var trackList = _unitOfWork.TrackInfo.GetAll(includeProps: "LocationInfo");
            return Json(new { data = trackList });
        }

        ////POST Delete
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.TrackInfo.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.TrackInfo.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Track Deleted successfully." });
            return RedirectToAction("Index");
        }
        #endregion
    }
}
