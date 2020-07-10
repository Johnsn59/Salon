using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShearBeatu.Models
{
    public class SubCategory
    {
        //  F i e l d s  &  P r o p e r t i e s

        [Key]
        public int                  SubCategoryID   { get; set; }
        public string               Name            { get; set; }
        public string               Description     { get; set; }
        public IEnumerable<Product> Products        { get; set; }

        //  C o n s t r u c t o r s

        //  M e t h o d s
        
    }
}
