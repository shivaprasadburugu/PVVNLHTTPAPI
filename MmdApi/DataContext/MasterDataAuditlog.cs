using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class MasterDataAuditlog
    {
        public string Discom { get; set; }
        public string Board { get; set; }
        public string Circle { get; set; }
        public string Division { get; set; }
        public string SubDivision { get; set; }
        public string Section { get; set; }
        public string Acno { get; set; }
        public string MeterNo { get; set; }
        public int? Category { get; set; }
        public int? SubCategory { get; set; }
        public double? CdKVa { get; set; }
        public string Unit { get; set; }
        public string ConsumerName { get; set; }
        public string Address { get; set; }
        public double? Mf { get; set; }
        public string Make { get; set; }
        public double? Phase { get; set; }
        public string DssLocation { get; set; }
        public string Hid { get; set; }
        public DateTime? ConnectionDate { get; set; }
        public int? PermanentPoleNumber { get; set; }
        public string ModemDcu { get; set; }
        public string MeterChangeFlag { get; set; }
        public string Flag { get; set; }
        public string ConsumerId { get; set; }
        public string ConsumerNo { get; set; }
        public string Substation { get; set; }
        public string Feeder { get; set; }
        public string ModemNumber { get; set; }
        public string ModemMdn { get; set; }
        public string SimProviderName { get; set; }
        public decimal? MobileNo { get; set; }
        public string Tod { get; set; }
        public string VoltageRating { get; set; }
        public string ModemManufacturerName { get; set; }
        public string BillingParameterType { get; set; }
        public string AvgUnits { get; set; }
        public string RelayStatus { get; set; }
        public string HappyHoursStart { get; set; }
        public string HappyHoursEnd { get; set; }
        public string EmergencyCredit { get; set; }
        public string InstantFreq { get; set; }
        public string RawFreq { get; set; }
        public string AlarmFreq { get; set; }
        public string MeterConnectionType { get; set; }
        public string EmergencyDays { get; set; }
        public string BrownPeriodDays { get; set; }
        public string MaxdemandPercentage { get; set; }
        public DateTime? BillindDate { get; set; }
        public string OverLoadLimit { get; set; }
        public string OvercurrentLimit { get; set; }
        public string UnderVoltage { get; set; }
        public string OverVoltage { get; set; }
        public string ProfileCapturedPeriod { get; set; }
        public string Topcovertamper { get; set; }
        public string InstailKwhReading { get; set; }
        public string DemandIntigration { get; set; }
        public string CommunicationSetting { get; set; }
        public string ReducedMaxDemand { get; set; }
        public string FeederCode { get; set; }
        public string FeederName { get; set; }
        public string DtrStructureCode { get; set; }
        public string DtrStructureName { get; set; }
        public string ModemSheduleCommunication { get; set; }
        public string IpAddress { get; set; }
        public string PortNumber { get; set; }
        public string MeterPhonenumber { get; set; }
        public string GatewayName { get; set; }
        public string ConnectionTime { get; set; }
        public string Uid { get; set; }
        public string IssueBelongsTo { get; set; }
        public string Description { get; set; }
        public string FieldPhoneNumber { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LedgerNo { get; set; }
        public string BillingCycle { get; set; }
        public string NetworkMapping { get; set; }
        public string MeterType { get; set; }
        public string LocationOfMeter { get; set; }
        public string AssetNo { get; set; }
        public DateTime? InsertedDate { get; set; }
    }
}
