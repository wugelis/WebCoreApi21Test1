using System;
using System.Collections.Generic;

namespace WebCoreApi21Test1.Models
{
    public partial class Account
    {
        public Account()
        {
            CustomerDetail = new HashSet<CustomerDetail>();
        }

        public string UserId { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public DateTime? ApplyDate { get; set; }

        public ICollection<CustomerDetail> CustomerDetail { get; set; }
    }
}
