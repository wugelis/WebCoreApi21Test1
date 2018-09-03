using System;
using System.Collections.Generic;

namespace WebCoreApi21Test1.Models
{
    public partial class QuestionnaireData
    {
        public string LoansType { get; set; }
        public string HousingAddress { get; set; }
        public int? HousingType { get; set; }
        public bool? IsHavePark { get; set; }
        public int? EstimateAmount { get; set; }
        public string ChtName { get; set; }
        public string Aid { get; set; }
    }
}
