using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShearBeatu.Models;

namespace ShearBeatu.Controllers
{
    public class ProductController : Controller
    {
        //   F i e l d s   &   P r o p e r t i e s

        private IProductRepository repository;
        public int PageSize { get; set; } = 4;

        //   C o n s t r u c t o r s

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        //   M e t h o d s

        //  C r e a t e

        [HttpGet]
        public IActionResult Add(int id)
        {
            Product p = new Product();
            p.SubCategoryID = id;
            return View(p);
        }

        [HttpPost]
        public IActionResult Add(Product p)
        {
            repository.Add(p);
            return RedirectToAction("Detail", "SubCategory", new { id = p.SubCategoryID });
        }

        //  R e a d

        public IActionResult Index(int productPage = 1)
        {
            IQueryable<Product> someProducts = repository.GetAllProducts()
             .OrderBy(p => p.ProductID)
             .Skip((productPage - 1) * PageSize)
             .Take(PageSize);
            return View(someProducts);

        }
        public IActionResult Detail(int id)
        {
            Product product = repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        //  U p d a t e

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Product product, int id)
        {
            product.ProductID = id;
            repository.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        //  D e l e t e

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Product product, int id)
        {
            repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
