using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class PrepaidConsumerBillingHistory
    {
        public string MeterNo { get; set; }
        public double OpenBalance { get; set; }
        public double OpenReading { get; set; }
        public double PresentReading { get; set; }
        public double Mf { get; set; }
        public double Consumption { get; set; }
        public double CumRcAmount { get; set; }
        public double FixedCharges { get; set; }
        public double CcCharges { get; set; }
        public double? EdChrages { get; set; }
        public double? EnergyCharges { get; set; }
        public double? TotalAmt { get; set; }
        public double? TotalCollamt { get; set; }
        public double? ClosedBalance { get; set; }
        public double? AvgUnits { get; set; }
        public double? ApproximateDays { get; set; }
        public DateTime CalculatedDate { get; set; }
        public DateTime BillingDate { get; set; }
        public double CreditJe { get; set; }
        public double DebitJe { get; set; }
        public double KvahOpenReading { get; set; }
        public double KvahPresentReading { get; set; }
        public double MdKw { get; set; }
        public double MdKva { get; set; }
        public string SignalStrength { get; set; }
        public string PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
