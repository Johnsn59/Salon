using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShearBeatu.Models
{
    public interface ISubCategoryRepository
    {
        //   C r e a t e

        SubCategory Add(SubCategory sc);

        //  R e a d

        IQueryable<SubCategory> GetAllSubCategories();
        SubCategory GetSubCategoryById(int SubCategoryID);
        IQueryable<SubCategory> GetSubCategoriesByKeyword(string keyword);

        //   U p d a t e

        SubCategory UpdateSubCategory(SubCategory sc);

        //  D e l e t e

        bool DeleteSubCategory(int id);
    }
}
