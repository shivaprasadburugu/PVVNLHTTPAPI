using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class PrepaidMeterLatestDetails
    {
        public string MeterNo { get; set; }
        public DateTime MeterReadDate { get; set; }
        public decimal? SlabRate { get; set; }
        public double? BalanceAmt { get; set; }
        public string RelayStatus { get; set; }
        public DateTime? CreditLimitDateTime { get; set; }
        public double? PresentReading { get; set; }
        public double? ConsumptionUnits { get; set; }
        public string PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
