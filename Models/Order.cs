using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShearBeatu.Models
{
    public class Order
    {
        //  F i e l d s  &  P r o p e r t i e s

        public int OrdersID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public double Freight { get; set; }

        //  C o n s t r u c t o r s

        //  M e t h o d s
    }
}
