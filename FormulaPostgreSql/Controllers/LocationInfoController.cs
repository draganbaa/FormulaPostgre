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
    public class LocationInfoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationInfoController(IUnitOfWork unitOfWork)
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
            LocationVM locationVM = new()
            {
                Location = new(),
                CountryList = _unitOfWork.Country.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Countryname,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                //create
                return View(locationVM);
            }
            else
            {
                //edit
                locationVM.Location = _unitOfWork.LocationInfo.GetFirstOrDefault(u => u.Id == id);
                return View(locationVM);
            }


        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(LocationVM obj)
        {

            if (ModelState.IsValid)
            {
                if(obj.Location.Id == 0)
                {
                    _unitOfWork.LocationInfo.Add(obj.Location);
                    TempData["success"] = "Location Created successfully";
                }
                else
                {
                    _unitOfWork.LocationInfo.Update(obj.Location);
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
            var locationList = _unitOfWork.LocationInfo.GetAll(includeProps: "Country");
            return Json(new { data = locationList });
        }

        ////POST Delete
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.LocationInfo.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.LocationInfo.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Location Deleted successfully." });
            return RedirectToAction("Index");
        }
        #endregion
    }
}
