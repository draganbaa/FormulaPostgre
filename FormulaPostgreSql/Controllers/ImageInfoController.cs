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
    public class ImageInfoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImageInfoController(IUnitOfWork unitOfWork)
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
            ImageVM imageVM = new()
            {
                ImageInfo = new(),
                TeamList = _unitOfWork.Team.GetAll().Select(i => new SelectListItem
                {
                    Text = i.TeamName,
                    Value = i.Id.ToString()
                }),
                DriverList = _unitOfWork.Driver.GetAll().Select(i => new SelectListItem
                {
                    Text = i.DriverName,
                    Value = i.Id.ToString()
                }),
                TrackList = _unitOfWork.TrackInfo.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Trackname,
                    Value = i.Id.ToString()
                }),
                CountryList = _unitOfWork.Country.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Countryname,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                //create
                return View(imageVM);
            }
            else
            {
                //edit
                imageVM.ImageInfo = _unitOfWork.ImageInfo.GetFirstOrDefault(u => u.Id == id);
                return View(imageVM);
            }


        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ImageVM obj)
        {

            if (ModelState.IsValid)
            {
                if(obj.ImageInfo.Id == 0)
                {
                    _unitOfWork.ImageInfo.Add(obj.ImageInfo);
                    TempData["success"] = "Image Created successfully";
                }
                else
                {
                    _unitOfWork.ImageInfo.Update(obj.ImageInfo);
                    TempData["success"] = "Image Updated successfully";
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
            var imageList = _unitOfWork.ImageInfo.GetAll(includeProps: "Team,Driver,TrackInfo,Country");
            return Json(new { data = imageList });
        }

        ////POST Delete
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.ImageInfo.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.ImageInfo.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Image Deleted successfully." });
            return RedirectToAction("Index");
        }
        #endregion
    }
}
