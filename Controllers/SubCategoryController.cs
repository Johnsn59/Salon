using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShearBeatu.Models;

namespace ShearBeatu.Controllers
{
    public class SubCategoryController : Controller
    {
        //   F i e l d s   &   P r o p e r t i e s

        private ISubCategoryRepository repository;

        //   C o n s t r u c t o r s

        public SubCategoryController(ISubCategoryRepository repository)
        {
            this.repository = repository;
        }

        //   M e t h o d s

        //  C r e a t e

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(SubCategory sc)
        {
            repository.Add(sc);
            return RedirectToAction("Index");
        }
        //  R e a d

        public IActionResult Index()
        {
            IQueryable<SubCategory> theSubCategory = repository.GetAllSubCategories().OrderBy(sc => sc.SubCategoryID);
            return View(theSubCategory);
        }

        public IActionResult Detail(int id)
        {
            SubCategory sc = repository.GetSubCategoryById(id);
            if (sc != null)
            {
                return View(sc);
            }
            return RedirectToAction("Index");
        }

        //  U p d a t e

        [HttpGet]
        public IActionResult Update(int id)
        {
            SubCategory sc = repository.GetSubCategoryById(id);
            if (sc != null)
            {
                return View(sc);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(SubCategory sc, int id)
        {
            sc.SubCategoryID = id;
            repository.UpdateSubCategory(sc);
            return RedirectToAction("Index");
        }

        //  D e l e t e

        [HttpGet]
        public IActionResult Delete(int id)
        {
            SubCategory sc = repository.GetSubCategoryById(id);
            if (sc != null)
            {
                return View(sc);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(SubCategory sc, int id)
        {
            repository.DeleteSubCategory(id);
            return RedirectToAction("Index");
        }

        //  U p d a t e

        //  D e l e t e
    }
}
