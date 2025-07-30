using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class DailyBilling
    {
        public string MeterNo { get; set; }
        public DateTime BillingDatetime { get; set; }
        public DateTime? BillingDate { get; set; }
        public double? CumEngyKWhImp { get; set; }
        public double? CumEngyKWhExp { get; set; }
        public double? CumEngyKVahImp { get; set; }
        public double? CumEngyKVahExp { get; set; }
        public double? CumEngyQi { get; set; }
        public double? CumEngyQii { get; set; }
        public double? CumEngyQiii { get; set; }
        public double? CumEngyQiv { get; set; }
        public DateTime? InsertedDate { get; set; }
    }
}
