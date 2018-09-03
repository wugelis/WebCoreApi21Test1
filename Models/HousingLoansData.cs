using System;
using System.Collections.Generic;

namespace WebCoreApi21Test1.Models
{
    public partial class HousingLoansData
    {
        public int? LoansAmount { get; set; }
        public string LoansHousingLocation { get; set; }
        public DateTime? LoansPeriodStart { get; set; }
        public DateTime? LoansPeriosEnd { get; set; }
        public string LoansUse { get; set; }
        public decimal? Rate { get; set; }
        public long CustomerId { get; set; }
        public long LoansId { get; set; }

        public CustomerDetail Customer { get; set; }
    }
}
