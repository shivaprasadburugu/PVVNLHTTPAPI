using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class EventsSummaryData
    {
        public string MeterNo { get; set; }
        public DateTime EventOccDatetime { get; set; }
        public DateTime? EventResDatetime { get; set; }
        public DateTime? Duration { get; set; }
        public string EventCode { get; set; }
        public string EventDescription { get; set; }
        public double? VoltageRPhaseOcc { get; set; }
        public double? VoltageYPhaseOcc { get; set; }
        public double? VoltageBPhaseOcc { get; set; }
        public double? CurrentRPhaseOcc { get; set; }
        public double? CurrentYPhaseOcc { get; set; }
        public double? CurrentBPhaseOcc { get; set; }
        public double? PfRPhaseOcc { get; set; }
        public double? PfYPhaseOcc { get; set; }
        public double? PfBPhaseOcc { get; set; }
        public double? ActiveCurrentRPhaseOcc { get; set; }
        public double? ActiveCurrentYPhaseOcc { get; set; }
        public double? ActiveCurrentBPhaseOcc { get; set; }
        public double? KWhImportOcc { get; set; }
        public double? KwhExportOcc { get; set; }
        public double? NeutralCurrentOcc { get; set; }
        public double? VoltageRPhaseRes { get; set; }
        public double? VoltageYPhaseRes { get; set; }
        public double? VoltageBPhaseRes { get; set; }
        public double? CurrentRPhaseRes { get; set; }
        public double? CurrentYPhaseRes { get; set; }
        public double? CurrentBPhaseRes { get; set; }
        public double? PfRPhaseRes { get; set; }
        public double? PfYPhaseRes { get; set; }
        public double? PfBPhaseRes { get; set; }
        public double? ActiveCurrentRPhaseRes { get; set; }
        public double? ActiveCurrentYPhaseRes { get; set; }
        public double? ActiveCurrentBPhaseRes { get; set; }
        public double? KWhImportRes { get; set; }
        public double? KwhExportRes { get; set; }
        public double? NeutralCurrentRes { get; set; }
        public DateTime? InsertedDate { get; set; }
    }
}
