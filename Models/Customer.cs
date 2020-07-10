using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShearBeatu.Models
{
    public class Customer
    {
        //  F i e l d s  &  P r o p e r t i e s

        public int CustomersID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CustomerName { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateRegion { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }

        //  C o n s t r u c t o r s

        //  M e t h o d s
    }
}
