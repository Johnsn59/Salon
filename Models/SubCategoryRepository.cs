using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShearBeatu.Models
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        private AppDbContext context;

        //   C o n s t r u c t o r s

        public SubCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        //   M e t h o d s

        //  C r e a t e

        public SubCategory Add(SubCategory sc)
        {
            try
            {
                context.SubCategories.Add(sc);
                context.SaveChanges();
                return sc;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //  R e a d

        public IQueryable<SubCategory> GetAllSubCategories()
        {
            return context.SubCategories.OrderBy(sc => sc.SubCategoryID);
        }
        public SubCategory GetSubCategoryById(int SubCategoryId)
        {
            SubCategory theSubCategory = context.SubCategories
                    .Where(sc => sc.SubCategoryID == SubCategoryId)
                    .Include(sc => sc.Products)
                    .FirstOrDefault();
            return theSubCategory;
        }
        public IQueryable<SubCategory> GetSubCategoriesByKeyword(string keyword)
        {
            return context.SubCategories.Where(p => p.Name.Contains(keyword))
                    .Include(sc => sc.Products);
        }

        //  U p d a t e

        public SubCategory UpdateSubCategory(SubCategory subCategory)
        {
            SubCategory SubCategoryToUpdate = context.SubCategories
               .SingleOrDefault(sc => sc.SubCategoryID == subCategory.SubCategoryID);
            if (SubCategoryToUpdate != null)
            {
                SubCategoryToUpdate.Name = subCategory.Name;
                SubCategoryToUpdate.Description = subCategory.Description;      
                context.SaveChanges();
            }
            return SubCategoryToUpdate;
        }

        //  D e l e t e

        public bool DeleteSubCategory(int id)
        {
            SubCategory SubCategoryToDelete = context.SubCategories
                .Include(sc => sc.Products)
                .FirstOrDefault(sc => sc.SubCategoryID == id);
            if (SubCategoryToDelete == null || SubCategoryToDelete.Products.Count() > 0)
            {
                return false;
            }
            context.SubCategories.Remove(SubCategoryToDelete);
            context.SaveChanges();
            return true;
        }
    }
}
