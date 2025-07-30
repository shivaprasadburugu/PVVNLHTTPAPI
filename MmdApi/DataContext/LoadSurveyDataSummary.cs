using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class LoadSurveyDataSummary
    {
        public string MeterNo { get; set; }
        public DateTime LsDatetime { get; set; }
        public DateTime? LsDate { get; set; }
        public double? KWhImport { get; set; }
        public string KWhImportUnit { get; set; }
        public double? KWhExport { get; set; }
        public string KWhExportUnit { get; set; }
        public double? KVahImport { get; set; }
        public string KVahImportUnit { get; set; }
        public double? KVahExport { get; set; }
        public string KVahExportUnit { get; set; }
        public double? KVarhImport { get; set; }
        public string KVarhImportUnit { get; set; }
        public double? KVarhExport { get; set; }
        public string KVarhExportUnit { get; set; }
        public double? KvarImport { get; set; }
        public string KVarImportUnit { get; set; }
        public double? KvarExport { get; set; }
        public string KVarExportUnit { get; set; }
        public double? KWImport { get; set; }
        public string KWImportUnit { get; set; }
        public double? KWExport { get; set; }
        public string KWExportUnit { get; set; }
        public double? KvaImport { get; set; }
        public string KVaImportUnit { get; set; }
        public double? KvaExport { get; set; }
        public string KVaExportUnit { get; set; }
        public double? CurrentRPhase { get; set; }
        public double? CurrentYPhase { get; set; }
        public double? CurrentBPhase { get; set; }
        public double? AvgCurrent { get; set; }
        public double? MinCurrent { get; set; }
        public double? MaxCurrent { get; set; }
        public double? VoltageRPhase { get; set; }
        public double? VoltageYPhase { get; set; }
        public double? VoltageBPhase { get; set; }
        public double? AvgVoltage { get; set; }
        public double? MinVoltage { get; set; }
        public double? MaxVoltage { get; set; }
        public double? PfRPhase { get; set; }
        public double? PfYPhase { get; set; }
        public double? PfBPhase { get; set; }
        public double? AvgPf { get; set; }
        public double? AvgFrequency { get; set; }
        public DateTime? InsertedDate { get; set; }
    }
}
