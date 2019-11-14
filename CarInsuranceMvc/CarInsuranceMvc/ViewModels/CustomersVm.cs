using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceMvc.ViewModels
{
    public class CustomersVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdd { get; set; }
        public int? InsuranceQuote { get; set; }
    }
}