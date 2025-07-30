using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class InstantData
    {
        public string MeterNo { get; set; }
        public DateTime RdateTime { get; set; }
        public double? ActivePower { get; set; }
        public double? ReactivePower { get; set; }
        public double? ApparentPower { get; set; }
        public double? ActiveEnergyImp { get; set; }
        public double? ActiveEnergyExp { get; set; }
        public double? ApparentEnergyImp { get; set; }
        public double? ApparentEnergyExp { get; set; }
        public double? ReactiveEnergyLagImp { get; set; }
        public double? ReactiveEnergyLagExp { get; set; }
        public double? ReactiveEnergyLeadImp { get; set; }
        public double? ReactiveEnergyLeadExp { get; set; }
        public double? VoltageRPhase { get; set; }
        public double? VoltageYPhase { get; set; }
        public double? VoltageBPhase { get; set; }
        public double? AvgVoltage { get; set; }
        public double? CurrentRPhase { get; set; }
        public double? CurrentYPhase { get; set; }
        public double? CurrentBPhase { get; set; }
        public double? AvgCurrent { get; set; }
        public double? PfRPhase { get; set; }
        public double? PfYPhase { get; set; }
        public double? PfBPhase { get; set; }
        public double? AvgPf { get; set; }
        public double? Frequnecy { get; set; }
        public DateTime? InsertedDate { get; set; }
    }
}
