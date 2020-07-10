using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShearBeatu.Models
{
    public class ProductRepository : IProductRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        private AppDbContext context;

        //   C o n s t r u c t o r s

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        //   M e t h o d s

        //  C r e a t e

        public Product Add(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //  R e a d

        public IQueryable<Product> GetAllProducts()
        {
            return context.Products.OrderBy(p => p.ProductID);
        }

        public IQueryable<Product> GetAllProducts(int subCategoryID)
        {
            return context.Products.Where(p => p.SubCategoryID == subCategoryID);
        }
        public Product GetProductById(int productId)
        {
            Product theProduct = context.Products
                    .Where(p => p.ProductID == productId)
                    .FirstOrDefault();
            return theProduct;
        }
        public IQueryable<Product> GetProductsByKeyword(string keyword)
        {
            return context.Products.Where(p => p.ProductName.Contains(keyword));
        }

        //  U p d a t e

        public Product UpdateProduct(Product product)
        {
            Product productToUpdate = context.Products
               .SingleOrDefault(p => p.ProductID == product.ProductID);
            if (productToUpdate != null)
            {
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.BrandName = product.BrandName;
                productToUpdate.Description = product.Description;
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.Discount = product.Discount;
                productToUpdate.SubCategoryID = product.SubCategoryID;
                context.SaveChanges();
            }
            return productToUpdate;
        }

        //  D e l e t e

        public bool DeleteProduct(int id)
        {
            Product productToDelete = context.Products.FirstOrDefault(p => p.ProductID == id);
            if (productToDelete == null)
            {
                return false;
            }
            context.Products.Remove(productToDelete);
            context.SaveChanges();
            return true;
        }
    }
}
