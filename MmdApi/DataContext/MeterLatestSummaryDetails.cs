using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class MeterLatestSummaryDetails
    {
        public string MeterNo { get; set; }
        public DateTime? MeterLastCommunication { get; set; }
        public DateTime? PresentDataCommunication { get; set; }
        public DateTime? DayChangeFilesCommunication { get; set; }
        public string MeterCurrentRelayStatus { get; set; }
        public string MeterCurrentSlabRate { get; set; }
        public decimal? MeterCurrentBalance { get; set; }
        public DateTime? RawReadDateTime { get; set; }
        public long? AlarmReadDateTime { get; set; }
        public string HappyHoursStart { get; set; }
        public string HappyHourEnd { get; set; }
        public string EmergencyDays { get; set; }
        public string EmergencyBrownDays { get; set; }
        public string EmergencyPercentage { get; set; }
        public string MeterMode { get; set; }
        public string BillingBase { get; set; }
        public string BalanceStatus { get; set; }
        public string G15 { get; set; }
        public string G17 { get; set; }
        public string G1221 { get; set; }
        public string G7 { get; set; }
        public string G8 { get; set; }
        public string G22 { get; set; }
        public int? TotalTampersCount { get; set; }
        public string IpAddress { get; set; }
        public string CommPort { get; set; }
        public string CommTime { get; set; }
        public string MdResetDate { get; set; }
        public string EmergencyCreditStatus { get; set; }
        public string MeterVersion { get; set; }
        public string PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? ConnectionDate { get; set; }
        public DateTime? DisconnectionDate { get; set; }
    }
}
