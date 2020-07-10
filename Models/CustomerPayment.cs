using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShearBeatu.Models
{
    public class CustomerPayment
    {
        //  F i e l d s  &  P r o p e r t i e s

        public int PaymentID { get; set; }
        public string CardType { get; set; }
        public string FinancialInstitusion { get; set; }
        public int AccountNumber { get; set; }
        public string BillingAddress { get; set; }
        public string City { get; set; }
        public string StateRegion { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }

        //  C o n s t r u c t o r s

        //  M e t h o d s
    }
}
