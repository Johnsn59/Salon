using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShearBeatu.Models
{
    public class Product
    {
        //  F i e l d s  &  P r o p e r t i e s

        [Key]
        public int              ProductID       { get; set; }
        public string           ProductName     { get; set; }
        public string           BrandName       { get; set; }
        public string           Description     { get; set; }
        public decimal          UnitPrice       { get; set; }
        public decimal          Discount        { get; set; }

        [ForeignKey("SubCategory")]
        public int              SubCategoryID { get; set; }
        public SubCategory      SubCategories   { get; set; }

            //  C o n s t r u c t o r s

            //  M e t h o d s
        }
}
