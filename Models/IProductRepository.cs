using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShearBeatu.Models
{
    public interface IProductRepository
    {
        //   C r e a t e

        Product Add(Product product);

        //  R e a d

        IQueryable<Product> GetAllProducts();
        IQueryable<Product> GetAllProducts(int subCategoryID);
        Product GetProductById(int productId);
        IQueryable<Product> GetProductsByKeyword(string keyword);

        //   U p d a t e

        Product UpdateProduct(Product product);

        //  D e l e t e

        bool DeleteProduct(int id);
    }
}
