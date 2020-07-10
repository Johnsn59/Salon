using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShearBeatu.Models
{
    public class OrdersDetail
    {
        //  F i e l d s  &  P r o p e r t i e s

        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string StateRegion { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }

        //  C o n s t r u c t o r s

        //  M e t h o d s
    }
}
