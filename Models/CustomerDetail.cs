using System;
using System.Collections.Generic;

namespace WebCoreApi21Test1.Models
{
    public partial class CustomerDetail
    {
        public CustomerDetail()
        {
            HousingLoansData = new HashSet<HousingLoansData>();
        }

        public string ChtName { get; set; }
        public string Aid { get; set; }
        public string Mobile { get; set; }
        public DateTime? Birthday { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string LocationNow { get; set; }
        public string Email { get; set; }
        public int? Marry { get; set; }
        public int? FamilyNum { get; set; }
        public string Education { get; set; }
        public long CustomerId { get; set; }
        public string UserId { get; set; }

        public Account User { get; set; }
        public ICollection<HousingLoansData> HousingLoansData { get; set; }
    }
}
