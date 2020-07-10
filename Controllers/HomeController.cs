using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShearBeatu.Models;

namespace ShearBeatu.Controllers
{
    public class HomeController : Controller
    {
        //   F i e l d s   &   P r o p e r t i e s

        private IProductRepository repository;
        public int PageSize { get; set; } = 4;

        //   C o n s t r u c t o r s

        public HomeController(IProductRepository repository)
        {
            this.repository = repository;
        }

        //   M e t h o d s

        //  C r e a t e

        //  R e a d

        public IActionResult Index(int productPage = 1)
        {
            IQueryable<Product> someProducts = repository.GetAllProducts()
             .OrderBy(p => p.ProductID)
             .Skip((productPage - 1) * PageSize)
             .Take(PageSize);
            return View(someProducts);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
