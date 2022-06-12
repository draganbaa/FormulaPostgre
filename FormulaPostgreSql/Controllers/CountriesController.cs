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

namespace FormulaPostgreSql.Controllers
{
    public class CountriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Country> data = _unitOfWork.Country.GetAll();

            return View(data);
        }

        //GET Create
        public IActionResult Create()
        {
            return View();
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Country.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Country Created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var country = _unitOfWork.Country.GetFirstOrDefault(u => u.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Country obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Country.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Country Updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Country.GetFirstOrDefault(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var category = _unitOfWork.Country.GetFirstOrDefault(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.Country.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Country Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
