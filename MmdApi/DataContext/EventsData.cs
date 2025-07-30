using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class EventsData
    {
        public string MeterNo { get; set; }
        public DateTime EventDatetime { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventCode { get; set; }
        public string EventDescription { get; set; }
        public double? VoltageRPhase { get; set; }
        public double? VoltageYPhase { get; set; }
        public double? VoltageBPhase { get; set; }
        public double? CurrentRPhase { get; set; }
        public double? CurrentYPhase { get; set; }
        public double? CurrentBPhase { get; set; }
        public double? PfRPhase { get; set; }
        public double? PfYPhase { get; set; }
        public double? PfBPhase { get; set; }
        public double? ActiveCurrentRPhase { get; set; }
        public double? ActiveCurrentYPhase { get; set; }
        public double? ActiveCurrentBPhase { get; set; }
        public double? KWhImport { get; set; }
        public double? KwhExport { get; set; }
        public int? TamperCount { get; set; }
        public double? NeutralCurrent { get; set; }
        public double? TotalPf { get; set; }
        public int? Temperature { get; set; }
        public DateTime? InsertedDate { get; set; }
    }
}
