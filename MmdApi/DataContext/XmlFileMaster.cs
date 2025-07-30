using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class XmlFileMaster
    {
        public string ModemManufacturername { get; set; }
        public string MeterFileName { get; set; }
        public string MeterNo { get; set; }
        public DateTime? MeterReadDate { get; set; }
        public DateTime? InsertedDate { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string GeneralData { get; set; }
        public string InstantData { get; set; }
        public string BillingData { get; set; }
        public string LoadsurveyData { get; set; }
        public string TamperData { get; set; }
        public string MidnightData { get; set; }
        public string TranscationData { get; set; }
        public string HealthData { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
