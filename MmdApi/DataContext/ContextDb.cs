using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MdmApi.DataContext
{
    public partial class ContextDb : DbContext
    {
        public ContextDb()
        {
        }

        public ContextDb(DbContextOptions<ContextDb> options)
            : base(options)
        {
        }
       

        public virtual DbSet<Configs> Configs { get; set; }
        public virtual DbSet<ConsumerTransactionLog> ConsumerTransactionLog { get; set; }
        public virtual DbSet<CustomerchargesMaster> CustomerchargesMaster { get; set; }
        public virtual DbSet<hexing_version> HexingVersion { get; set; }
        public virtual DbSet<DailyBilling> DailyBilling { get; set; }
        public virtual DbSet<EventsData> EventsData { get; set; }
        public virtual DbSet<EventsSummaryData> EventsSummaryData { get; set; }
        public virtual DbSet<FixedChargesMaster> FixedChargesMaster { get; set; }
        public virtual DbSet<HolidayMaster> HolidayMaster { get; set; }
        public virtual DbSet<InstantData> InstantData { get; set; }
        public virtual DbSet<LoadSurveyData> LoadSurveyData { get; set; }
        public virtual DbSet<LoadSurveyData24hrs> LoadSurveyData24hrs { get; set; }
        public virtual DbSet<LoadSurveyDataSummary> LoadSurveyDataSummary { get; set; }
        public virtual DbSet<MasBoard> MasBoard { get; set; }
        public virtual DbSet<MasCircle> MasCircle { get; set; }
        public virtual DbSet<MasDiscom> MasDiscom { get; set; }
        public virtual DbSet<MasDivision> MasDivision { get; set; }
        public virtual DbSet<MasGroupmaster> MasGroupmaster { get; set; }
        public virtual DbSet<MasRole> MasRole { get; set; }
        public virtual DbSet<MasRolePage> MasRolePage { get; set; }
        public virtual DbSet<MasScopeAccessLevel> MasScopeAccessLevel { get; set; }
        public virtual DbSet<MasSection> MasSection { get; set; }
        public virtual DbSet<MasSubdivision> MasSubdivision { get; set; }
        public virtual DbSet<MasValidationRule> MasValidationRule { get; set; }
        public virtual DbSet<MasValidationRuleAudit> MasValidationRuleAudit { get; set; }
        public virtual DbSet<MasXmlEventsDesc> MasXmlEventsDesc { get; set; }
        public virtual DbSet<MasterData> MasterData { get; set; }
        public virtual DbSet<MasterDataAuditlog> MasterDataAuditlog { get; set; }
        public virtual DbSet<MeterCommandMaster> MeterCommandMaster { get; set; }
        public virtual DbSet<MeterCommunicationLog> MeterCommunicationLog { get; set; }
        public virtual DbSet<MeterLatestSummaryDetails> MeterLatestSummaryDetails { get; set; }
        public virtual DbSet<MeterRequestMaster> MeterRequestMaster { get; set; }
        public virtual DbSet<MeterRequestTranslog> MeterRequestTranslog { get; set; }
        public virtual DbSet<MonthlyBillingData> MonthlyBillingData { get; set; }
        public virtual DbSet<NavBar> NavBar { get; set; }
        public virtual DbSet<PrepaidConsumerBillingHistory> PrepaidConsumerBillingHistory { get; set; }
        public virtual DbSet<PrepaidCurInstantaneous> PrepaidCurInstantaneous { get; set; }
        public virtual DbSet<PrepaidDailyBillingHistory> PrepaidDailyBillingHistory { get; set; }
        public virtual DbSet<PrepaidLedger> PrepaidLedger { get; set; }
        public virtual DbSet<PrepaidMeterLatestDetails> PrepaidMeterLatestDetails { get; set; }
        public virtual DbSet<RealtimeTamperMaster> RealtimeTamperMaster { get; set; }
        public virtual DbSet<TariffunitsMaster> TariffunitsMaster { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }
        public virtual DbSet<UserToken> UserToken { get; set; }
        public virtual DbSet<XmlFileMaster> XmlFileMaster { get; set; }
        public virtual DbSet<ZeroHistoryBillingData> ZeroHistoryBillingData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //  optionsBuilder.UseSqlServer("Server=172.16.0.201;Database=Analogics_Mdm;User Id=mdms;Password=mdms@123;");
                optionsBuilder.UseNpgsql("Server=172.16.0.209;Port=5432;Database=mdms_test;User Id=postgres;Password=postgres@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configs>(entity =>
            {
                entity.HasKey(e => e.ConfigId)
                    .HasName("pk_configs");

                entity.Property(e => e.ConfigId).HasColumnName("Config_Id");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("Created_On")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("Modified_On")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConsumerTransactionLog>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("cons_trans_log_pk");

                entity.ToTable("Consumer_Transaction_Log");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("Payment_Id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerId)
                    .HasColumnName("Consumer_Id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MeterBalance)
                    .HasColumnName("Meter_Balance")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionAmount)
                    .HasColumnName("Transaction_Amount")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionCompleteDate)
                    .HasColumnName("Transaction_Complete_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("Transaction_Id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionReceivedDate)
                    .HasColumnName("Transaction_received_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .HasColumnName("Transaction_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UtilityTransactionDate)
                    .HasColumnName("Utility_Transaction_Date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<CustomerchargesMaster>(entity =>
            {
                entity.HasKey(e => new { e.Slno, e.Category, e.SubCategory })
                    .HasName("PK_CUSTOMERCHARGES_MASTER");

                entity.ToTable("Customercharges_Master");

                entity.HasIndex(e => new { e.Category, e.Ccrate })
                    .HasName("IND_CUSTCHG");

                entity.Property(e => e.Slno).ValueGeneratedOnAdd();

                entity.Property(e => e.SubCategory).HasColumnName("Sub_Category");

                entity.Property(e => e.Ccrate).HasColumnName("CCRATE");

                entity.Property(e => e.Edrate).HasColumnName("EDRATE");

                entity.Property(e => e.Slabenddate).HasColumnType("datetime");

                entity.Property(e => e.Slabstartdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DailyBilling>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.BillingDatetime })
                    .HasName("daily_bill");

                entity.ToTable("Daily_Billing");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("IND_daily_billing");

                entity.HasIndex(e => new { e.MeterNo, e.BillingDate })
                    .HasName("IND_daily_bill");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BillingDatetime)
                    .HasColumnName("Billing_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.BillingDate)
                    .HasColumnName("Billing_date")
                    .HasColumnType("date");

                entity.Property(e => e.CumEngyKVahExp).HasColumnName("CumEngy_kVah_Exp");

                entity.Property(e => e.CumEngyKVahImp).HasColumnName("CumEngy_kVah_Imp");

                entity.Property(e => e.CumEngyKWhExp).HasColumnName("CumEngy_kWh_Exp");

                entity.Property(e => e.CumEngyKWhImp).HasColumnName("CumEngy_kWh_Imp");

                entity.Property(e => e.CumEngyQi).HasColumnName("CumEngy_QI");

                entity.Property(e => e.CumEngyQii).HasColumnName("CumEngy_QII");

                entity.Property(e => e.CumEngyQiii).HasColumnName("CumEngy_QIII");

                entity.Property(e => e.CumEngyQiv).HasColumnName("CumEngy_QIV");

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_Date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<EventsData>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.EventDatetime })
                    .HasName("PK_events");

                entity.ToTable("Events_Data");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("ind_event");

                entity.HasIndex(e => new { e.MeterNo, e.EventDate })
                    .HasName("ind_eventdata");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EventDatetime)
                    .HasColumnName("Event_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActiveCurrentBPhase).HasColumnName("ActiveCurrent_B_Phase");

                entity.Property(e => e.ActiveCurrentRPhase).HasColumnName("ActiveCurrent_R_Phase");

                entity.Property(e => e.ActiveCurrentYPhase).HasColumnName("ActiveCurrent_Y_Phase");

                entity.Property(e => e.CurrentBPhase).HasColumnName("Current_B_Phase");

                entity.Property(e => e.CurrentRPhase).HasColumnName("Current_R_Phase");

                entity.Property(e => e.CurrentYPhase).HasColumnName("Current_Y_Phase");

                entity.Property(e => e.EventCode)
                    .HasColumnName("Event_Code")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.EventDate)
                    .HasColumnName("Event_Date")
                    .HasColumnType("date");

                entity.Property(e => e.EventDescription)
                    .HasColumnName("Event_Description")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWhImport).HasColumnName("kWh_Import");

                entity.Property(e => e.KwhExport).HasColumnName("KWh_Export");

                entity.Property(e => e.NeutralCurrent).HasColumnName("Neutral_Current");

                entity.Property(e => e.PfBPhase).HasColumnName("PF_B_Phase");

                entity.Property(e => e.PfRPhase).HasColumnName("PF_R_Phase");

                entity.Property(e => e.PfYPhase).HasColumnName("PF_Y_Phase");

                entity.Property(e => e.TamperCount).HasColumnName("Tamper_Count");

                entity.Property(e => e.TotalPf).HasColumnName("Total_PF");

                entity.Property(e => e.VoltageBPhase).HasColumnName("Voltage_B_Phase");

                entity.Property(e => e.VoltageRPhase).HasColumnName("Voltage_R_Phase");

                entity.Property(e => e.VoltageYPhase).HasColumnName("Voltage_Y_Phase");
            });

            modelBuilder.Entity<EventsSummaryData>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.EventOccDatetime })
                    .HasName("PK_events_summary");

                entity.ToTable("Events_Summary_Data");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("ind_events_sum_mtr");

                entity.HasIndex(e => new { e.MeterNo, e.EventOccDatetime })
                    .HasName("ind_events_sum");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EventOccDatetime)
                    .HasColumnName("Event_OccDatetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActiveCurrentBPhaseOcc).HasColumnName("ActiveCurrent_B_Phase_Occ");

                entity.Property(e => e.ActiveCurrentBPhaseRes).HasColumnName("ActiveCurrent_B_Phase_Res");

                entity.Property(e => e.ActiveCurrentRPhaseOcc).HasColumnName("ActiveCurrent_R_Phase_Occ");

                entity.Property(e => e.ActiveCurrentRPhaseRes).HasColumnName("ActiveCurrent_R_Phase_Res");

                entity.Property(e => e.ActiveCurrentYPhaseOcc).HasColumnName("ActiveCurrent_Y_Phase_Occ");

                entity.Property(e => e.ActiveCurrentYPhaseRes).HasColumnName("ActiveCurrent_Y_Phase_Res");

                entity.Property(e => e.CurrentBPhaseOcc).HasColumnName("Current_B_Phase_Occ");

                entity.Property(e => e.CurrentBPhaseRes).HasColumnName("Current_B_Phase_Res");

                entity.Property(e => e.CurrentRPhaseOcc).HasColumnName("Current_R_Phase_Occ");

                entity.Property(e => e.CurrentRPhaseRes).HasColumnName("Current_R_Phase_Res");

                entity.Property(e => e.CurrentYPhaseOcc).HasColumnName("Current_Y_Phase_Occ");

                entity.Property(e => e.CurrentYPhaseRes).HasColumnName("Current_Y_Phase_Res");

                entity.Property(e => e.Duration).HasColumnType("datetime");

                entity.Property(e => e.EventCode)
                    .HasColumnName("Event_Code")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.EventDescription)
                    .HasColumnName("Event_Description")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EventResDatetime)
                    .HasColumnName("Event_ResDatetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWhImportOcc).HasColumnName("kWh_Import_Occ");

                entity.Property(e => e.KWhImportRes).HasColumnName("kWh_Import_Res");

                entity.Property(e => e.KwhExportOcc).HasColumnName("KWh_Export_Occ");

                entity.Property(e => e.KwhExportRes).HasColumnName("KWh_Export_Res");

                entity.Property(e => e.NeutralCurrentOcc).HasColumnName("Neutral_Current_Occ");

                entity.Property(e => e.NeutralCurrentRes).HasColumnName("Neutral_Current_Res");

                entity.Property(e => e.PfBPhaseOcc).HasColumnName("PF_B_Phase_Occ");

                entity.Property(e => e.PfBPhaseRes).HasColumnName("PF_B_Phase_Res");

                entity.Property(e => e.PfRPhaseOcc).HasColumnName("PF_R_Phase_Occ");

                entity.Property(e => e.PfRPhaseRes).HasColumnName("PF_R_Phase_Res");

                entity.Property(e => e.PfYPhaseOcc).HasColumnName("PF_Y_Phase_Occ");

                entity.Property(e => e.PfYPhaseRes).HasColumnName("PF_Y_Phase_Res");

                entity.Property(e => e.VoltageBPhaseOcc).HasColumnName("Voltage_B_Phase_Occ");

                entity.Property(e => e.VoltageBPhaseRes).HasColumnName("Voltage_B_Phase_Res");

                entity.Property(e => e.VoltageRPhaseOcc).HasColumnName("Voltage_R_Phase_Occ");

                entity.Property(e => e.VoltageRPhaseRes).HasColumnName("Voltage_R_Phase_Res");

                entity.Property(e => e.VoltageYPhaseOcc).HasColumnName("Voltage_Y_Phase_Occ");

                entity.Property(e => e.VoltageYPhaseRes).HasColumnName("Voltage_Y_Phase_Res");
            });

            modelBuilder.Entity<FixedChargesMaster>(entity =>
            {
                entity.HasKey(e => new { e.Slno, e.Category, e.SubCategory });

                entity.ToTable("FixedCharges_Master");

                entity.Property(e => e.Slno).ValueGeneratedOnAdd();

                entity.Property(e => e.SubCategory).HasColumnName("Sub_Category");

                entity.Property(e => e.FcRate).HasColumnName("FC_RATE");

                entity.Property(e => e.SlabEnddate)
                    .HasColumnName("Slab_enddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SlabStartdate)
                    .HasColumnName("Slab_startdate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<HolidayMaster>(entity =>
            {
                entity.HasKey(e => e.HolidayDate)
                    .HasName("holiday_master_PK");

                entity.ToTable("Holiday_Master");

                entity.HasIndex(e => e.HolidayDate)
                    .HasName("IND_holiday");

                entity.Property(e => e.HolidayDate)
                    .HasColumnName("Holiday_Date")
                    .HasColumnType("date");

                entity.Property(e => e.HolidayDesc)
                    .HasColumnName("Holiday_Desc")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDateTime)
                    .HasColumnName("Updated_DateTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<InstantData>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.RdateTime })
                    .HasName("instant_data_pk");

                entity.ToTable("Instant_data");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("IND_instdata");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RdateTime).HasColumnType("datetime");

                entity.Property(e => e.ActiveEnergyExp).HasColumnName("Active_EnergyExp");

                entity.Property(e => e.ActiveEnergyImp).HasColumnName("Active_EnergyImp");

                entity.Property(e => e.ActivePower).HasColumnName("Active_Power");

                entity.Property(e => e.ApparentEnergyExp).HasColumnName("Apparent_EnergyExp");

                entity.Property(e => e.ApparentEnergyImp).HasColumnName("Apparent_EnergyImp");

                entity.Property(e => e.ApparentPower).HasColumnName("Apparent_Power");

                entity.Property(e => e.AvgCurrent).HasColumnName("Avg_Current");

                entity.Property(e => e.AvgPf).HasColumnName("Avg_PF");

                entity.Property(e => e.AvgVoltage).HasColumnName("Avg_voltage");

                entity.Property(e => e.CurrentBPhase).HasColumnName("Current_B_Phase");

                entity.Property(e => e.CurrentRPhase).HasColumnName("Current_R_Phase");

                entity.Property(e => e.CurrentYPhase).HasColumnName("Current_Y_Phase");

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PfBPhase).HasColumnName("PF_B_Phase");

                entity.Property(e => e.PfRPhase).HasColumnName("PF_R_Phase");

                entity.Property(e => e.PfYPhase).HasColumnName("PF_Y_Phase");

                entity.Property(e => e.ReactiveEnergyLagExp).HasColumnName("Reactive_EnergyLagExp");

                entity.Property(e => e.ReactiveEnergyLagImp).HasColumnName("Reactive_EnergyLagImp");

                entity.Property(e => e.ReactiveEnergyLeadExp).HasColumnName("Reactive_EnergyLeadExp");

                entity.Property(e => e.ReactiveEnergyLeadImp).HasColumnName("Reactive_EnergyLeadImp");

                entity.Property(e => e.ReactivePower).HasColumnName("Reactive_Power");

                entity.Property(e => e.VoltageBPhase).HasColumnName("Voltage_B_Phase");

                entity.Property(e => e.VoltageRPhase).HasColumnName("Voltage_R_Phase");

                entity.Property(e => e.VoltageYPhase).HasColumnName("Voltage_Y_Phase");
            });

            modelBuilder.Entity<LoadSurveyData>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.LsDatetime, e.Interval, e.Intervalid })
                    .HasName("lsdata_pk");

                entity.ToTable("LoadSurvey_Data");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("IND_lsdata");

                entity.HasIndex(e => new { e.MeterNo, e.LsDate })
                    .HasName("IND_lsdata_date");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LsDatetime)
                    .HasColumnName("Ls_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AvgCurrent).HasColumnName("Avg_current");

                entity.Property(e => e.AvgFrequency).HasColumnName("Avg_Frequency");

                entity.Property(e => e.AvgPf).HasColumnName("Avg_Pf");

                entity.Property(e => e.AvgVoltage).HasColumnName("Avg_voltage");

                entity.Property(e => e.CurrentBPhase).HasColumnName("Current_B_Phase");

                entity.Property(e => e.CurrentRPhase).HasColumnName("Current_R_Phase");

                entity.Property(e => e.CurrentYPhase).HasColumnName("Current_Y_Phase");

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaExportUnit)
                    .HasColumnName("kVa_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVaImportUnit)
                    .HasColumnName("kVa_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVahExport).HasColumnName("kVah_Export");

                entity.Property(e => e.KVahExportUnit)
                    .HasColumnName("kVah_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVahImport).HasColumnName("kVah_Import");

                entity.Property(e => e.KVahImportUnit)
                    .HasColumnName("kVah_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVarExportUnit)
                    .HasColumnName("kVar_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVarImportUnit)
                    .HasColumnName("kVar_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVarhExport).HasColumnName("kVarh_Export");

                entity.Property(e => e.KVarhExportUnit)
                    .HasColumnName("kVarh_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVarhImport).HasColumnName("kVarh_Import");

                entity.Property(e => e.KVarhImportUnit)
                    .HasColumnName("kVarh_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KWExport).HasColumnName("kW_Export");

                entity.Property(e => e.KWExportUnit)
                    .HasColumnName("kW_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KWImport).HasColumnName("kW_Import");

                entity.Property(e => e.KWImportUnit)
                    .HasColumnName("kW_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KWhExport).HasColumnName("kWh_Export");

                entity.Property(e => e.KWhExportUnit)
                    .HasColumnName("kWh_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KWhImport).HasColumnName("kWh_Import");

                entity.Property(e => e.KWhImportUnit)
                    .HasColumnName("kWh_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KvaExport).HasColumnName("Kva_Export");

                entity.Property(e => e.KvaImport).HasColumnName("Kva_Import");

                entity.Property(e => e.KvarExport).HasColumnName("Kvar_Export");

                entity.Property(e => e.KvarImport).HasColumnName("Kvar_Import");

                entity.Property(e => e.LsDate)
                    .HasColumnName("Ls_Date")
                    .HasColumnType("date");

                entity.Property(e => e.MaxCurrent).HasColumnName("Max_Current");

                entity.Property(e => e.MaxVoltage).HasColumnName("Max_Voltage");

                entity.Property(e => e.MinCurrent).HasColumnName("Min_Current");

                entity.Property(e => e.MinVoltage).HasColumnName("Min_Voltage");

                entity.Property(e => e.PfBPhase).HasColumnName("Pf_B_Phase");

                entity.Property(e => e.PfRPhase).HasColumnName("Pf_R_Phase");

                entity.Property(e => e.PfYPhase).HasColumnName("Pf_Y_Phase");

                entity.Property(e => e.VoltageBPhase).HasColumnName("Voltage_B_Phase");

                entity.Property(e => e.VoltageRPhase).HasColumnName("Voltage_R_Phase");

                entity.Property(e => e.VoltageYPhase).HasColumnName("Voltage_Y_Phase");
            });

            modelBuilder.Entity<LoadSurveyData24hrs>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.LsDate })
                    .HasName("Lsdata_summary_pk");

                entity.ToTable("LoadSurvey_Data_24Hrs");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("ind_ldata_24hr");

                entity.HasIndex(e => new { e.MeterNo, e.LsDate })
                    .HasName("ind_ldata24hr");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LsDate)
                    .HasColumnName("Ls_Date")
                    .HasColumnType("date");

                entity.Property(e => e.AvgCurrent).HasColumnName("Avg_current");

                entity.Property(e => e.AvgPf).HasColumnName("Avg_Pf");

                entity.Property(e => e.AvgVoltage).HasColumnName("Avg_voltage");

                entity.Property(e => e.CurrentBPhase).HasColumnName("Current_B_Phase");

                entity.Property(e => e.CurrentRPhase).HasColumnName("Current_R_Phase");

                entity.Property(e => e.CurrentYPhase).HasColumnName("Current_Y_Phase");

                entity.Property(e => e.KVahExport).HasColumnName("kVah_Export");

                entity.Property(e => e.KVahImport).HasColumnName("kVah_Import");

                entity.Property(e => e.KVahImport1).HasColumnName("kVah_Import1");

                entity.Property(e => e.KVahImport10).HasColumnName("kVah_Import10");

                entity.Property(e => e.KVahImport11).HasColumnName("kVah_Import11");

                entity.Property(e => e.KVahImport12).HasColumnName("kVah_Import12");

                entity.Property(e => e.KVahImport13).HasColumnName("kVah_Import13");

                entity.Property(e => e.KVahImport14).HasColumnName("kVah_Import14");

                entity.Property(e => e.KVahImport15).HasColumnName("kVah_Import15");

                entity.Property(e => e.KVahImport16).HasColumnName("kVah_Import16");

                entity.Property(e => e.KVahImport17).HasColumnName("kVah_Import17");

                entity.Property(e => e.KVahImport18).HasColumnName("kVah_Import18");

                entity.Property(e => e.KVahImport19).HasColumnName("kVah_Import19");

                entity.Property(e => e.KVahImport2).HasColumnName("kVah_Import2");

                entity.Property(e => e.KVahImport20).HasColumnName("kVah_Import20");

                entity.Property(e => e.KVahImport21).HasColumnName("kVah_Import21");

                entity.Property(e => e.KVahImport22).HasColumnName("kVah_Import22");

                entity.Property(e => e.KVahImport23).HasColumnName("kVah_Import23");

                entity.Property(e => e.KVahImport24).HasColumnName("kVah_Import24");

                entity.Property(e => e.KVahImport3).HasColumnName("kVah_Import3");

                entity.Property(e => e.KVahImport4).HasColumnName("kVah_Import4");

                entity.Property(e => e.KVahImport5).HasColumnName("kVah_Import5");

                entity.Property(e => e.KVahImport6).HasColumnName("kVah_Import6");

                entity.Property(e => e.KVahImport7).HasColumnName("kVah_Import7");

                entity.Property(e => e.KVahImport8).HasColumnName("kVah_Import8");

                entity.Property(e => e.KVahImport9).HasColumnName("kVah_Import9");

                entity.Property(e => e.KVarhExport).HasColumnName("kVarh_Export");

                entity.Property(e => e.KVarhExport1).HasColumnName("kVarh_Export1");

                entity.Property(e => e.KVarhExport10).HasColumnName("kVarh_Export10");

                entity.Property(e => e.KVarhExport11).HasColumnName("kVarh_Export11");

                entity.Property(e => e.KVarhExport12).HasColumnName("kVarh_Export12");

                entity.Property(e => e.KVarhExport13).HasColumnName("kVarh_Export13");

                entity.Property(e => e.KVarhExport14).HasColumnName("kVarh_Export14");

                entity.Property(e => e.KVarhExport15).HasColumnName("kVarh_Export15");

                entity.Property(e => e.KVarhExport16).HasColumnName("kVarh_Export16");

                entity.Property(e => e.KVarhExport17).HasColumnName("kVarh_Export17");

                entity.Property(e => e.KVarhExport18).HasColumnName("kVarh_Export18");

                entity.Property(e => e.KVarhExport19).HasColumnName("kVarh_Export19");

                entity.Property(e => e.KVarhExport2).HasColumnName("kVarh_Export2");

                entity.Property(e => e.KVarhExport20).HasColumnName("kVarh_Export20");

                entity.Property(e => e.KVarhExport21).HasColumnName("kVarh_Export21");

                entity.Property(e => e.KVarhExport22).HasColumnName("kVarh_Export22");

                entity.Property(e => e.KVarhExport23).HasColumnName("kVarh_Export23");

                entity.Property(e => e.KVarhExport24).HasColumnName("kVarh_Export24");

                entity.Property(e => e.KVarhExport3).HasColumnName("kVarh_Export3");

                entity.Property(e => e.KVarhExport4).HasColumnName("kVarh_Export4");

                entity.Property(e => e.KVarhExport5).HasColumnName("kVarh_Export5");

                entity.Property(e => e.KVarhExport6).HasColumnName("kVarh_Export6");

                entity.Property(e => e.KVarhExport7).HasColumnName("kVarh_Export7");

                entity.Property(e => e.KVarhExport8).HasColumnName("kVarh_Export8");

                entity.Property(e => e.KVarhExport9).HasColumnName("kVarh_Export9");

                entity.Property(e => e.KVarhImport).HasColumnName("kVarh_Import");

                entity.Property(e => e.KVarhImport0).HasColumnName("kVarh_Import0");

                entity.Property(e => e.KVarhImport1).HasColumnName("kVarh_Import1");

                entity.Property(e => e.KVarhImport11).HasColumnName("kVarh_Import11");

                entity.Property(e => e.KVarhImport12).HasColumnName("kVarh_Import12");

                entity.Property(e => e.KVarhImport13).HasColumnName("kVarh_Import13");

                entity.Property(e => e.KVarhImport14).HasColumnName("kVarh_Import14");

                entity.Property(e => e.KVarhImport15).HasColumnName("kVarh_Import15");

                entity.Property(e => e.KVarhImport16).HasColumnName("kVarh_Import16");

                entity.Property(e => e.KVarhImport17).HasColumnName("kVarh_Import17");

                entity.Property(e => e.KVarhImport18).HasColumnName("kVarh_Import18");

                entity.Property(e => e.KVarhImport19).HasColumnName("kVarh_Import19");

                entity.Property(e => e.KVarhImport2).HasColumnName("kVarh_Import2");

                entity.Property(e => e.KVarhImport20).HasColumnName("kVarh_Import20");

                entity.Property(e => e.KVarhImport21).HasColumnName("kVarh_Import21");

                entity.Property(e => e.KVarhImport22).HasColumnName("kVarh_Import22");

                entity.Property(e => e.KVarhImport23).HasColumnName("kVarh_Import23");

                entity.Property(e => e.KVarhImport24).HasColumnName("kVarh_Import24");

                entity.Property(e => e.KVarhImport3).HasColumnName("kVarh_Import3");

                entity.Property(e => e.KVarhImport4).HasColumnName("kVarh_Import4");

                entity.Property(e => e.KVarhImport5).HasColumnName("kVarh_Import5");

                entity.Property(e => e.KVarhImport6).HasColumnName("kVarh_Import6");

                entity.Property(e => e.KVarhImport7).HasColumnName("kVarh_Import7");

                entity.Property(e => e.KVarhImport8).HasColumnName("kVarh_Import8");

                entity.Property(e => e.KVarhImport9).HasColumnName("kVarh_Import9");

                entity.Property(e => e.KWExport1).HasColumnName("kW_Export1");

                entity.Property(e => e.KWExport10).HasColumnName("kW_Export10");

                entity.Property(e => e.KWExport11).HasColumnName("kW_Export11");

                entity.Property(e => e.KWExport12).HasColumnName("kW_Export12");

                entity.Property(e => e.KWExport13).HasColumnName("kW_Export13");

                entity.Property(e => e.KWExport14).HasColumnName("kW_Export14");

                entity.Property(e => e.KWExport15).HasColumnName("kW_Export15");

                entity.Property(e => e.KWExport16).HasColumnName("kW_Export16");

                entity.Property(e => e.KWExport17).HasColumnName("kW_Export17");

                entity.Property(e => e.KWExport18).HasColumnName("kW_Export18");

                entity.Property(e => e.KWExport19).HasColumnName("kW_Export19");

                entity.Property(e => e.KWExport2).HasColumnName("kW_Export2");

                entity.Property(e => e.KWExport20).HasColumnName("kW_Export20");

                entity.Property(e => e.KWExport21).HasColumnName("kW_Export21");

                entity.Property(e => e.KWExport22).HasColumnName("kW_Export22");

                entity.Property(e => e.KWExport23).HasColumnName("kW_Export23");

                entity.Property(e => e.KWExport24).HasColumnName("kW_Export24");

                entity.Property(e => e.KWExport3).HasColumnName("kW_Export3");

                entity.Property(e => e.KWExport4).HasColumnName("kW_Export4");

                entity.Property(e => e.KWExport5).HasColumnName("kW_Export5");

                entity.Property(e => e.KWExport6).HasColumnName("kW_Export6");

                entity.Property(e => e.KWExport7).HasColumnName("kW_Export7");

                entity.Property(e => e.KWExport8).HasColumnName("kW_Export8");

                entity.Property(e => e.KWExport9).HasColumnName("kW_Export9");

                entity.Property(e => e.KWImport1).HasColumnName("kW_Import1");

                entity.Property(e => e.KWImport10).HasColumnName("kW_Import10");

                entity.Property(e => e.KWImport11).HasColumnName("kW_Import11");

                entity.Property(e => e.KWImport12).HasColumnName("kW_Import12");

                entity.Property(e => e.KWImport13).HasColumnName("kW_Import13");

                entity.Property(e => e.KWImport14).HasColumnName("kW_Import14");

                entity.Property(e => e.KWImport15).HasColumnName("kW_Import15");

                entity.Property(e => e.KWImport16).HasColumnName("kW_Import16");

                entity.Property(e => e.KWImport17).HasColumnName("kW_Import17");

                entity.Property(e => e.KWImport18).HasColumnName("kW_Import18");

                entity.Property(e => e.KWImport19).HasColumnName("kW_Import19");

                entity.Property(e => e.KWImport2).HasColumnName("kW_Import2");

                entity.Property(e => e.KWImport20).HasColumnName("kW_Import20");

                entity.Property(e => e.KWImport21).HasColumnName("kW_Import21");

                entity.Property(e => e.KWImport22).HasColumnName("kW_Import22");

                entity.Property(e => e.KWImport23).HasColumnName("kW_Import23");

                entity.Property(e => e.KWImport24).HasColumnName("kW_Import24");

                entity.Property(e => e.KWImport3).HasColumnName("kW_Import3");

                entity.Property(e => e.KWImport4).HasColumnName("kW_Import4");

                entity.Property(e => e.KWImport5).HasColumnName("kW_Import5");

                entity.Property(e => e.KWImport6).HasColumnName("kW_Import6");

                entity.Property(e => e.KWImport7).HasColumnName("kW_Import7");

                entity.Property(e => e.KWImport8).HasColumnName("kW_Import8");

                entity.Property(e => e.KWImport9).HasColumnName("kW_Import9");

                entity.Property(e => e.KWhExportCons).HasColumnName("kWh_Export_Cons");

                entity.Property(e => e.KWhImportCons).HasColumnName("kWh_Import_Cons");

                entity.Property(e => e.KvaExport).HasColumnName("Kva_Export");

                entity.Property(e => e.KvaExport1).HasColumnName("Kva_Export1");

                entity.Property(e => e.KvaExport10).HasColumnName("Kva_Export10");

                entity.Property(e => e.KvaExport11).HasColumnName("Kva_Export11");

                entity.Property(e => e.KvaExport12).HasColumnName("Kva_Export12");

                entity.Property(e => e.KvaExport13).HasColumnName("Kva_Export13");

                entity.Property(e => e.KvaExport14).HasColumnName("Kva_Export14");

                entity.Property(e => e.KvaExport15).HasColumnName("Kva_Export15");

                entity.Property(e => e.KvaExport16).HasColumnName("Kva_Export16");

                entity.Property(e => e.KvaExport17).HasColumnName("Kva_Export17");

                entity.Property(e => e.KvaExport18).HasColumnName("Kva_Export18");

                entity.Property(e => e.KvaExport19).HasColumnName("Kva_Export19");

                entity.Property(e => e.KvaExport2).HasColumnName("Kva_Export2");

                entity.Property(e => e.KvaExport20).HasColumnName("Kva_Export20");

                entity.Property(e => e.KvaExport21).HasColumnName("Kva_Export21");

                entity.Property(e => e.KvaExport22).HasColumnName("Kva_Export22");

                entity.Property(e => e.KvaExport23).HasColumnName("Kva_Export23");

                entity.Property(e => e.KvaExport24).HasColumnName("Kva_Export24");

                entity.Property(e => e.KvaExport3).HasColumnName("Kva_Export3");

                entity.Property(e => e.KvaExport4).HasColumnName("Kva_Export4");

                entity.Property(e => e.KvaExport5).HasColumnName("Kva_Export5");

                entity.Property(e => e.KvaExport6).HasColumnName("Kva_Export6");

                entity.Property(e => e.KvaExport7).HasColumnName("Kva_Export7");

                entity.Property(e => e.KvaExport8).HasColumnName("Kva_Export8");

                entity.Property(e => e.KvaExport9).HasColumnName("Kva_Export9");

                entity.Property(e => e.KvaImport).HasColumnName("Kva_Import");

                entity.Property(e => e.KvaImport1).HasColumnName("Kva_Import1");

                entity.Property(e => e.KvaImport10).HasColumnName("Kva_Import10");

                entity.Property(e => e.KvaImport11).HasColumnName("Kva_Import11");

                entity.Property(e => e.KvaImport12).HasColumnName("Kva_Import12");

                entity.Property(e => e.KvaImport13).HasColumnName("Kva_Import13");

                entity.Property(e => e.KvaImport14).HasColumnName("Kva_Import14");

                entity.Property(e => e.KvaImport15).HasColumnName("Kva_Import15");

                entity.Property(e => e.KvaImport16).HasColumnName("Kva_Import16");

                entity.Property(e => e.KvaImport17).HasColumnName("Kva_Import17");

                entity.Property(e => e.KvaImport18).HasColumnName("Kva_Import18");

                entity.Property(e => e.KvaImport19).HasColumnName("Kva_Import19");

                entity.Property(e => e.KvaImport2).HasColumnName("Kva_Import2");

                entity.Property(e => e.KvaImport20).HasColumnName("Kva_Import20");

                entity.Property(e => e.KvaImport21).HasColumnName("Kva_Import21");

                entity.Property(e => e.KvaImport22).HasColumnName("Kva_Import22");

                entity.Property(e => e.KvaImport23).HasColumnName("Kva_Import23");

                entity.Property(e => e.KvaImport24).HasColumnName("Kva_Import24");

                entity.Property(e => e.KvaImport3).HasColumnName("Kva_Import3");

                entity.Property(e => e.KvaImport4).HasColumnName("Kva_Import4");

                entity.Property(e => e.KvaImport5).HasColumnName("Kva_Import5");

                entity.Property(e => e.KvaImport6).HasColumnName("Kva_Import6");

                entity.Property(e => e.KvaImport7).HasColumnName("Kva_Import7");

                entity.Property(e => e.KvaImport8).HasColumnName("Kva_Import8");

                entity.Property(e => e.KvaImport9).HasColumnName("Kva_Import9");

                entity.Property(e => e.KvahExport1).HasColumnName("KVah_Export1");

                entity.Property(e => e.KvahExport10).HasColumnName("KVah_Export10");

                entity.Property(e => e.KvahExport11).HasColumnName("KVah_Export11");

                entity.Property(e => e.KvahExport12).HasColumnName("KVah_Export12");

                entity.Property(e => e.KvahExport13).HasColumnName("KVah_Export13");

                entity.Property(e => e.KvahExport14).HasColumnName("KVah_Export14");

                entity.Property(e => e.KvahExport15).HasColumnName("KVah_Export15");

                entity.Property(e => e.KvahExport16).HasColumnName("KVah_Export16");

                entity.Property(e => e.KvahExport17).HasColumnName("KVah_Export17");

                entity.Property(e => e.KvahExport18).HasColumnName("KVah_Export18");

                entity.Property(e => e.KvahExport19).HasColumnName("KVah_Export19");

                entity.Property(e => e.KvahExport2).HasColumnName("KVah_Export2");

                entity.Property(e => e.KvahExport20).HasColumnName("KVah_Export20");

                entity.Property(e => e.KvahExport21).HasColumnName("KVah_Export21");

                entity.Property(e => e.KvahExport22).HasColumnName("KVah_Export22");

                entity.Property(e => e.KvahExport23).HasColumnName("KVah_Export23");

                entity.Property(e => e.KvahExport24).HasColumnName("KVah_Export24");

                entity.Property(e => e.KvahExport3).HasColumnName("KVah_Export3");

                entity.Property(e => e.KvahExport4).HasColumnName("KVah_Export4");

                entity.Property(e => e.KvahExport5).HasColumnName("KVah_Export5");

                entity.Property(e => e.KvahExport6).HasColumnName("KVah_Export6");

                entity.Property(e => e.KvahExport7).HasColumnName("KVah_Export7");

                entity.Property(e => e.KvahExport8).HasColumnName("KVah_Export8");

                entity.Property(e => e.KvahExport9).HasColumnName("KVah_Export9");

                entity.Property(e => e.KvarExport).HasColumnName("Kvar_Export");

                entity.Property(e => e.KvarExport1).HasColumnName("Kvar_Export1");

                entity.Property(e => e.KvarExport10).HasColumnName("Kvar_Export10");

                entity.Property(e => e.KvarExport11).HasColumnName("Kvar_Export11");

                entity.Property(e => e.KvarExport12).HasColumnName("Kvar_Export12");

                entity.Property(e => e.KvarExport13).HasColumnName("Kvar_Export13");

                entity.Property(e => e.KvarExport14).HasColumnName("Kvar_Export14");

                entity.Property(e => e.KvarExport15).HasColumnName("Kvar_Export15");

                entity.Property(e => e.KvarExport16).HasColumnName("Kvar_Export16");

                entity.Property(e => e.KvarExport17).HasColumnName("Kvar_Export17");

                entity.Property(e => e.KvarExport18).HasColumnName("Kvar_Export18");

                entity.Property(e => e.KvarExport19).HasColumnName("Kvar_Export19");

                entity.Property(e => e.KvarExport2).HasColumnName("Kvar_Export2");

                entity.Property(e => e.KvarExport20).HasColumnName("Kvar_Export20");

                entity.Property(e => e.KvarExport21).HasColumnName("Kvar_Export21");

                entity.Property(e => e.KvarExport22).HasColumnName("Kvar_Export22");

                entity.Property(e => e.KvarExport23).HasColumnName("Kvar_Export23");

                entity.Property(e => e.KvarExport24).HasColumnName("Kvar_Export24");

                entity.Property(e => e.KvarExport3).HasColumnName("Kvar_Export3");

                entity.Property(e => e.KvarExport4).HasColumnName("Kvar_Export4");

                entity.Property(e => e.KvarExport5).HasColumnName("Kvar_Export5");

                entity.Property(e => e.KvarExport6).HasColumnName("Kvar_Export6");

                entity.Property(e => e.KvarExport7).HasColumnName("Kvar_Export7");

                entity.Property(e => e.KvarExport8).HasColumnName("Kvar_Export8");

                entity.Property(e => e.KvarExport9).HasColumnName("Kvar_Export9");

                entity.Property(e => e.KvarImport).HasColumnName("Kvar_Import");

                entity.Property(e => e.KvarImport1).HasColumnName("Kvar_Import1");

                entity.Property(e => e.KvarImport10).HasColumnName("Kvar_Import10");

                entity.Property(e => e.KvarImport11).HasColumnName("Kvar_Import11");

                entity.Property(e => e.KvarImport12).HasColumnName("Kvar_Import12");

                entity.Property(e => e.KvarImport13).HasColumnName("Kvar_Import13");

                entity.Property(e => e.KvarImport14).HasColumnName("Kvar_Import14");

                entity.Property(e => e.KvarImport15).HasColumnName("Kvar_Import15");

                entity.Property(e => e.KvarImport16).HasColumnName("Kvar_Import16");

                entity.Property(e => e.KvarImport17).HasColumnName("Kvar_Import17");

                entity.Property(e => e.KvarImport18).HasColumnName("Kvar_Import18");

                entity.Property(e => e.KvarImport19).HasColumnName("Kvar_Import19");

                entity.Property(e => e.KvarImport2).HasColumnName("Kvar_Import2");

                entity.Property(e => e.KvarImport20).HasColumnName("Kvar_Import20");

                entity.Property(e => e.KvarImport21).HasColumnName("Kvar_Import21");

                entity.Property(e => e.KvarImport22).HasColumnName("Kvar_Import22");

                entity.Property(e => e.KvarImport23).HasColumnName("Kvar_Import23");

                entity.Property(e => e.KvarImport24).HasColumnName("Kvar_Import24");

                entity.Property(e => e.KvarImport3).HasColumnName("Kvar_Import3");

                entity.Property(e => e.KvarImport4).HasColumnName("Kvar_Import4");

                entity.Property(e => e.KvarImport5).HasColumnName("Kvar_Import5");

                entity.Property(e => e.KvarImport6).HasColumnName("Kvar_Import6");

                entity.Property(e => e.KvarImport7).HasColumnName("Kvar_Import7");

                entity.Property(e => e.KvarImport8).HasColumnName("Kvar_Import8");

                entity.Property(e => e.KvarImport9).HasColumnName("Kvar_Import9");

                entity.Property(e => e.KwExportMaxDem).HasColumnName("Kw_Export_MaxDem");

                entity.Property(e => e.KwImportMaxDem).HasColumnName("Kw_Import_MaxDem");

                entity.Property(e => e.KwhExport1).HasColumnName("Kwh_Export1");

                entity.Property(e => e.KwhExport10).HasColumnName("Kwh_Export10");

                entity.Property(e => e.KwhExport11).HasColumnName("Kwh_Export11");

                entity.Property(e => e.KwhExport12).HasColumnName("Kwh_Export12");

                entity.Property(e => e.KwhExport13).HasColumnName("Kwh_Export13");

                entity.Property(e => e.KwhExport14).HasColumnName("Kwh_Export14");

                entity.Property(e => e.KwhExport15).HasColumnName("Kwh_Export15");

                entity.Property(e => e.KwhExport16).HasColumnName("Kwh_Export16");

                entity.Property(e => e.KwhExport17).HasColumnName("Kwh_Export17");

                entity.Property(e => e.KwhExport18).HasColumnName("Kwh_Export18");

                entity.Property(e => e.KwhExport19).HasColumnName("Kwh_Export19");

                entity.Property(e => e.KwhExport2).HasColumnName("Kwh_Export2");

                entity.Property(e => e.KwhExport20).HasColumnName("Kwh_Export20");

                entity.Property(e => e.KwhExport21).HasColumnName("Kwh_Export21");

                entity.Property(e => e.KwhExport22).HasColumnName("Kwh_Export22");

                entity.Property(e => e.KwhExport23).HasColumnName("Kwh_Export23");

                entity.Property(e => e.KwhExport24).HasColumnName("Kwh_Export24");

                entity.Property(e => e.KwhExport3).HasColumnName("Kwh_Export3");

                entity.Property(e => e.KwhExport4).HasColumnName("Kwh_Export4");

                entity.Property(e => e.KwhExport5).HasColumnName("Kwh_Export5");

                entity.Property(e => e.KwhExport6).HasColumnName("Kwh_Export6");

                entity.Property(e => e.KwhExport7).HasColumnName("Kwh_Export7");

                entity.Property(e => e.KwhExport8).HasColumnName("Kwh_Export8");

                entity.Property(e => e.KwhExport9).HasColumnName("Kwh_Export9");

                entity.Property(e => e.KwhImport1).HasColumnName("Kwh_Import1");

                entity.Property(e => e.KwhImport10).HasColumnName("Kwh_Import10");

                entity.Property(e => e.KwhImport11).HasColumnName("Kwh_Import11");

                entity.Property(e => e.KwhImport12).HasColumnName("Kwh_Import12");

                entity.Property(e => e.KwhImport13).HasColumnName("Kwh_Import13");

                entity.Property(e => e.KwhImport14).HasColumnName("Kwh_Import14");

                entity.Property(e => e.KwhImport15).HasColumnName("Kwh_Import15");

                entity.Property(e => e.KwhImport16).HasColumnName("Kwh_Import16");

                entity.Property(e => e.KwhImport17).HasColumnName("Kwh_Import17");

                entity.Property(e => e.KwhImport18).HasColumnName("Kwh_Import18");

                entity.Property(e => e.KwhImport19).HasColumnName("Kwh_Import19");

                entity.Property(e => e.KwhImport2).HasColumnName("Kwh_Import2");

                entity.Property(e => e.KwhImport20).HasColumnName("Kwh_Import20");

                entity.Property(e => e.KwhImport21).HasColumnName("Kwh_Import21");

                entity.Property(e => e.KwhImport22).HasColumnName("Kwh_Import22");

                entity.Property(e => e.KwhImport23).HasColumnName("Kwh_Import23");

                entity.Property(e => e.KwhImport24).HasColumnName("Kwh_Import24");

                entity.Property(e => e.KwhImport3).HasColumnName("Kwh_Import3");

                entity.Property(e => e.KwhImport4).HasColumnName("Kwh_Import4");

                entity.Property(e => e.KwhImport5).HasColumnName("Kwh_Import5");

                entity.Property(e => e.KwhImport6).HasColumnName("Kwh_Import6");

                entity.Property(e => e.KwhImport7).HasColumnName("Kwh_Import7");

                entity.Property(e => e.KwhImport8).HasColumnName("Kwh_Import8");

                entity.Property(e => e.KwhImport9).HasColumnName("Kwh_Import9");

                entity.Property(e => e.LsdataCnt).HasColumnName("Lsdata_Cnt");

                entity.Property(e => e.PfBPhase).HasColumnName("Pf_B_Phase");

                entity.Property(e => e.PfRPhase).HasColumnName("Pf_R_Phase");

                entity.Property(e => e.PfYPhase).HasColumnName("Pf_Y_Phase");

                entity.Property(e => e.VoltageBPhase).HasColumnName("Voltage_B_Phase");

                entity.Property(e => e.VoltageRPhase).HasColumnName("Voltage_R_Phase");

                entity.Property(e => e.VoltageYPhase).HasColumnName("Voltage_Y_Phase");
            });

            modelBuilder.Entity<LoadSurveyDataSummary>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.LsDatetime })
                    .HasName("lsdata_sum_pk");

                entity.ToTable("LoadSurvey_Data_Summary");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("ind_ldata_sum");

                entity.HasIndex(e => new { e.MeterNo, e.LsDate })
                    .HasName("ind_ldatasum");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LsDatetime)
                    .HasColumnName("Ls_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AvgCurrent).HasColumnName("Avg_current");

                entity.Property(e => e.AvgFrequency).HasColumnName("Avg_Frequency");

                entity.Property(e => e.AvgPf).HasColumnName("Avg_Pf");

                entity.Property(e => e.AvgVoltage).HasColumnName("Avg_voltage");

                entity.Property(e => e.CurrentBPhase).HasColumnName("Current_B_Phase");

                entity.Property(e => e.CurrentRPhase).HasColumnName("Current_R_Phase");

                entity.Property(e => e.CurrentYPhase).HasColumnName("Current_Y_Phase");

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaExportUnit)
                    .HasColumnName("kVa_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVaImportUnit)
                    .HasColumnName("kVa_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVahExport).HasColumnName("kVah_Export");

                entity.Property(e => e.KVahExportUnit)
                    .HasColumnName("kVah_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVahImport).HasColumnName("kVah_Import");

                entity.Property(e => e.KVahImportUnit)
                    .HasColumnName("kVah_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVarExportUnit)
                    .HasColumnName("kVar_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVarImportUnit)
                    .HasColumnName("kVar_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVarhExport).HasColumnName("kVarh_Export");

                entity.Property(e => e.KVarhExportUnit)
                    .HasColumnName("kVarh_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KVarhImport).HasColumnName("kVarh_Import");

                entity.Property(e => e.KVarhImportUnit)
                    .HasColumnName("kVarh_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KWExport).HasColumnName("kW_Export");

                entity.Property(e => e.KWExportUnit)
                    .HasColumnName("kW_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KWImport).HasColumnName("kW_Import");

                entity.Property(e => e.KWImportUnit)
                    .HasColumnName("kW_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KWhExport).HasColumnName("kWh_Export");

                entity.Property(e => e.KWhExportUnit)
                    .HasColumnName("kWh_ExportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KWhImport).HasColumnName("kWh_Import");

                entity.Property(e => e.KWhImportUnit)
                    .HasColumnName("kWh_ImportUnit")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.KvaExport).HasColumnName("Kva_Export");

                entity.Property(e => e.KvaImport).HasColumnName("Kva_Import");

                entity.Property(e => e.KvarExport).HasColumnName("Kvar_Export");

                entity.Property(e => e.KvarImport).HasColumnName("Kvar_Import");

                entity.Property(e => e.LsDate)
                    .HasColumnName("Ls_Date")
                    .HasColumnType("date");

                entity.Property(e => e.MaxCurrent).HasColumnName("Max_Current");

                entity.Property(e => e.MaxVoltage).HasColumnName("Max_Voltage");

                entity.Property(e => e.MinCurrent).HasColumnName("Min_Current");

                entity.Property(e => e.MinVoltage).HasColumnName("Min_Voltage");

                entity.Property(e => e.PfBPhase).HasColumnName("Pf_B_Phase");

                entity.Property(e => e.PfRPhase).HasColumnName("Pf_R_Phase");

                entity.Property(e => e.PfYPhase).HasColumnName("Pf_Y_Phase");

                entity.Property(e => e.VoltageBPhase).HasColumnName("Voltage_B_Phase");

                entity.Property(e => e.VoltageRPhase).HasColumnName("Voltage_R_Phase");

                entity.Property(e => e.VoltageYPhase).HasColumnName("Voltage_Y_Phase");
            });

            modelBuilder.Entity<MasBoard>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("board_pk");

                entity.ToTable("Mas_Board");

                entity.Property(e => e.Bid)
                    .HasColumnName("BID")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Boardname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Did)
                    .HasColumnName("DID")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MasCircle>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("circle_pk");

                entity.ToTable("Mas_Circle");

                entity.Property(e => e.Cid)
                    .HasColumnName("CID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Bid)
                    .HasColumnName("BID")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Circlename)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasDiscom>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("discom_pk");

                entity.ToTable("Mas_Discom");

                entity.Property(e => e.Did)
                    .HasColumnName("DID")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DiscomName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasDivision>(entity =>
            {
                entity.HasKey(e => e.Divid)
                    .HasName("division_pk");

                entity.ToTable("Mas_Division");

                entity.Property(e => e.Divid)
                    .HasColumnName("DIVID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Cid)
                    .HasColumnName("CID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Divisionname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasGroupmaster>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.MeterNo })
                    .HasName("GRP_PK");

                entity.ToTable("Mas_Groupmaster");

                entity.HasIndex(e => e.GroupId)
                    .HasName("ind_grp_id");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("ind_grp_mtr");

                entity.Property(e => e.GroupId)
                    .HasColumnName("Group_Id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GroupDesc)
                    .HasColumnName("Group_Desc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegionId)
                    .HasColumnName("Region_Id")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("Role_pk");

                entity.ToTable("Mas_Role");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.InsertedBy)
                    .HasColumnName("Inserted_By")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleType)
                    .HasColumnName("Role_Type")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasRolePage>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.HeaderDesc, e.PageId })
                    .HasName("pk_ROLEPAGE");

                entity.ToTable("Mas_RolePage");

                entity.Property(e => e.RoleId)
                    .HasColumnName("Role_Id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HeaderDesc)
                    .HasColumnName("Header_Desc")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PageId)
                    .HasColumnName("Page_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasScopeAccessLevel>(entity =>
            {
                entity.HasKey(e => e.ScopeId)
                    .HasName("pk_Scope");

                entity.ToTable("Mas_Scope_Access_Level");

                entity.Property(e => e.ScopeId).HasColumnName("Scope_Id");

                entity.Property(e => e.InsertedBy)
                    .HasColumnName("Inserted_By")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScopeName)
                    .HasColumnName("Scope_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasSection>(entity =>
            {
                entity.HasKey(e => e.Secid)
                    .HasName("SECTION_pk");

                entity.ToTable("Mas_Section");

                entity.Property(e => e.Secid)
                    .HasColumnName("SECID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Sectionname)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Subdivid)
                    .HasColumnName("SUBDIVID")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasSubdivision>(entity =>
            {
                entity.HasKey(e => e.Subdivid)
                    .HasName("subdivision_pk");

                entity.ToTable("Mas_Subdivision");

                entity.Property(e => e.Subdivid)
                    .HasColumnName("SUBDIVID")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Divid)
                    .HasColumnName("DIVID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Subdivisionname)
                    .HasColumnName("subdivisionname")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasValidationRule>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Mas_Validation_Rule");

                entity.HasIndex(e => new { e.RuleId, e.RuleName })
                    .HasName("IND_mst_valrule");

                entity.Property(e => e.Condition)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Config)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Module)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Parameter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RuleFormula)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RuleId).ValueGeneratedOnAdd();

                entity.Property(e => e.RuleName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Units)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasValidationRuleAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Mas_Validation_Rule_Audit");

                entity.HasIndex(e => e.RuleId)
                    .HasName("IND_mst_valruleaud");

                entity.Property(e => e.Action)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ChangedDatetime)
                    .HasColumnName("Changed_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewRule)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OldRule)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasXmlEventsDesc>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("pk_eventdesc");

                entity.ToTable("Mas_Xml_Events_Desc");

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.EventsDesc)
                    .HasColumnName("Events_Desc")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasterData>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.AssetNo })
                    .HasName("mstsdata_pk");

                entity.ToTable("Master_data");

                entity.HasIndex(e => e.AssetNo)
                    .HasName("IND_MST_ASS");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("IND_MST");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AssetNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Acno)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AlarmFreq)
                    .HasColumnName("Alarm_Freq")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AvgUnits)
                    .HasColumnName("Avg_Units")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BillindDate).HasColumnType("datetime");

                entity.Property(e => e.BillingCycle)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BillingParameterType)
                    .HasColumnName("BillingParameter_Type")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Board)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BrownPeriodDays)
                    .HasColumnName("BrownPeriod_days")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CdKVa).HasColumnName("Cd_kVa");

                entity.Property(e => e.Circle)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CommunicationSetting)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConnectionDate)
                    .HasColumnName("Connection_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConnectionTime)
                    .HasColumnName("Connection_time")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerId)
                    .HasColumnName("Consumer_Id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerName)
                    .HasColumnName("Consumer_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerNo)
                    .HasColumnName("Consumer_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DemandIntigration)
                    .HasColumnName("Demand_Intigration")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Discom)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Division)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DssLocation)
                    .HasColumnName("Dss_Location")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DtrStructureCode)
                    .HasColumnName("Dtr_StructureCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DtrStructureName)
                    .HasColumnName("Dtr_StructureName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyCredit)
                    .HasColumnName("Emergency_Credit")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyDays)
                    .HasColumnName("Emergency_days")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Feeder)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FeederCode)
                    .HasColumnName("Feeder_Code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FeederName)
                    .HasColumnName("Feeder_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FieldPhoneNumber)
                    .HasColumnName("fieldPhoneNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Flag)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.GatewayName)
                    .HasColumnName("Gateway_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HappyHoursEnd)
                    .HasColumnName("HappyHours_End")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HappyHoursStart)
                    .HasColumnName("HappyHours_Start")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Hid)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InstailKwhReading)
                    .HasColumnName("Instail_KwhReading")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InstantFreq)
                    .HasColumnName("Instant_Freq")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("Ip_Address")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IssueBelongsTo)
                    .HasColumnName("Issue_BelongsTo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LedgerNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LocationOfMeter)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Make)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaxdemandPercentage)
                    .HasColumnName("Maxdemand_Percentage")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MeterChangeFlag)
                    .HasColumnName("Meter_CHange_Flag")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MeterConnectionType)
                    .HasColumnName("MeterConnection_Type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MeterPhonenumber)
                    .HasColumnName("Meter_Phonenumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MeterType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasColumnName("Mobile_No")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ModemDcu)
                    .HasColumnName("Modem_Dcu")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModemManufacturerName)
                    .HasColumnName("Modem_ManufacturerName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModemMdn)
                    .HasColumnName("Modem_Mdn")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModemNumber)
                    .HasColumnName("Modem_Number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModemSheduleCommunication)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NetworkMapping)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OverLoadLimit)
                    .HasColumnName("OverLoad_Limit")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OverVoltage)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OvercurrentLimit)
                    .HasColumnName("Overcurrent_Limit")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PermanentPoleNumber).HasColumnName("Permanent_PoleNumber");

                entity.Property(e => e.PortNumber)
                    .HasColumnName("Port_Number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileCapturedPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RawFreq)
                    .HasColumnName("Raw_Freq")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReducedMaxDemand)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RelayStatus)
                    .HasColumnName("Relay_status")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SimProviderName)
                    .HasColumnName("Sim_Provider_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubCategory).HasColumnName("Sub_Category");

                entity.Property(e => e.SubDivision)
                    .HasColumnName("Sub_Division")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Substation)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tod)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Topcovertamper)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UnderVoltage)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.VoltageRating)
                    .HasColumnName("Voltage_Rating")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasterDataAuditlog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Master_data_Auditlog");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("IND_mst_audit");

                entity.Property(e => e.Acno)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AlarmFreq)
                    .HasColumnName("Alarm_Freq")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AssetNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AvgUnits)
                    .HasColumnName("Avg_Units")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BillindDate).HasColumnType("datetime");

                entity.Property(e => e.BillingCycle)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BillingParameterType)
                    .HasColumnName("BillingParameter_Type")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Board)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BrownPeriodDays)
                    .HasColumnName("BrownPeriod_days")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CdKVa).HasColumnName("Cd_kVa");

                entity.Property(e => e.Circle)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CommunicationSetting)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConnectionDate)
                    .HasColumnName("Connection_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConnectionTime)
                    .HasColumnName("Connection_time")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerId)
                    .HasColumnName("Consumer_Id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerName)
                    .HasColumnName("Consumer_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerNo)
                    .HasColumnName("Consumer_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DemandIntigration)
                    .HasColumnName("Demand_Intigration")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Discom)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Division)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DssLocation)
                    .HasColumnName("Dss_Location")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DtrStructureCode)
                    .HasColumnName("Dtr_StructureCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DtrStructureName)
                    .HasColumnName("Dtr_StructureName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyCredit)
                    .HasColumnName("Emergency_Credit")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyDays)
                    .HasColumnName("Emergency_days")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Feeder)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FeederCode)
                    .HasColumnName("Feeder_Code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FeederName)
                    .HasColumnName("Feeder_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FieldPhoneNumber)
                    .HasColumnName("fieldPhoneNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Flag)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.GatewayName)
                    .HasColumnName("Gateway_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HappyHoursEnd)
                    .HasColumnName("HappyHours_End")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HappyHoursStart)
                    .HasColumnName("HappyHours_Start")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Hid)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InstailKwhReading)
                    .HasColumnName("Instail_KwhReading")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InstantFreq)
                    .HasColumnName("Instant_Freq")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("Ip_Address")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IssueBelongsTo)
                    .HasColumnName("Issue_BelongsTo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LedgerNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LocationOfMeter)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Make)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaxdemandPercentage)
                    .HasColumnName("Maxdemand_Percentage")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MeterChangeFlag)
                    .HasColumnName("Meter_CHange_Flag")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MeterConnectionType)
                    .HasColumnName("MeterConnection_Type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MeterPhonenumber)
                    .HasColumnName("Meter_Phonenumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MeterType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasColumnName("Mobile_No")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ModemDcu)
                    .HasColumnName("Modem_Dcu")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModemManufacturerName)
                    .HasColumnName("Modem_ManufacturerName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModemMdn)
                    .HasColumnName("Modem_Mdn")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModemNumber)
                    .HasColumnName("Modem_Number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModemSheduleCommunication)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NetworkMapping)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OverLoadLimit)
                    .HasColumnName("OverLoad_Limit")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OverVoltage)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OvercurrentLimit)
                    .HasColumnName("Overcurrent_Limit")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PermanentPoleNumber).HasColumnName("Permanent_PoleNumber");

                entity.Property(e => e.PortNumber)
                    .HasColumnName("Port_Number")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileCapturedPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RawFreq)
                    .HasColumnName("Raw_Freq")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReducedMaxDemand)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RelayStatus)
                    .HasColumnName("Relay_status")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Section)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SimProviderName)
                    .HasColumnName("Sim_Provider_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubCategory).HasColumnName("Sub_Category");

                entity.Property(e => e.SubDivision)
                    .HasColumnName("Sub_Division")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Substation)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tod)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Topcovertamper)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UnderVoltage)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.VoltageRating)
                    .HasColumnName("Voltage_Rating")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MeterCommandMaster>(entity =>
            {
                entity.HasKey(e => e.CommandName)
                    .HasName("PK_meter_command_master");

                entity.ToTable("Meter_Command_Master");

                entity.Property(e => e.CommandName)
                    .HasColumnName("Command_Name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CommandCode)
                    .IsRequired()
                    .HasColumnName("Command_Code")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CommandGroup)
                    .HasColumnName("Command_Group")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CommandType)
                    .HasColumnName("Command_Type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsCompleteCommand)
                    .HasColumnName("IsComplete_Command")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MeterCommunicationLog>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.UpdatedDate })
                    .HasName("PK_dbo.meter_communication_log");

                entity.ToTable("Meter_Communication_Log");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("Updated_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CommunicationType)
                    .HasColumnName("Communication_Type")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.RemarksType)
                    .HasColumnName("Remarks_Type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusOfCommunication)
                    .HasColumnName("StatusOf_Communication")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MeterLatestSummaryDetails>(entity =>
            {
                entity.HasKey(e => e.MeterNo)
                    .HasName("PK_dbo.meter_latest_summary_details");

                entity.ToTable("Meter_Latest_Summary_Details");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("ind_mtr_latsum");

                entity.HasIndex(e => new { e.MeterNo, e.MeterLastCommunication })
                    .HasName("ind_mtr_lat_sum");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.AlarmReadDateTime).HasColumnName("AlarmRead_DateTime");

                entity.Property(e => e.BalanceStatus)
                    .HasColumnName("Balance_Status")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.BillingBase)
                    .HasColumnName("Billing_Base")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CommPort)
                    .HasColumnName("Comm_Port")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CommTime)
                    .HasColumnName("Comm_Time")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ConnectionDate)
                    .HasColumnName("Connection_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DayChangeFilesCommunication)
                    .HasColumnName("DayChangeFiles_Communication")
                    .HasColumnType("datetime");

                entity.Property(e => e.DisconnectionDate)
                    .HasColumnName("Disconnection_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmergencyBrownDays)
                    .HasColumnName("Emergency_BrownDays")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyCreditStatus)
                    .HasColumnName("Emergency_Credit_Status")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyDays)
                    .HasColumnName("Emergency_Days")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyPercentage)
                    .HasColumnName("Emergency_Percentage")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.G1221)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.G15)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.G17)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.G22)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.G7)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.G8)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.HappyHourEnd)
                    .HasColumnName("HappyHour_End")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HappyHoursStart)
                    .HasColumnName("HappyHours_Start")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("Ip_Address")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.MdResetDate)
                    .HasColumnName("Md_ResetDate")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.MeterCurrentBalance)
                    .HasColumnName("MeterCurrent_Balance")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.MeterCurrentRelayStatus)
                    .HasColumnName("MeterCurrent_RelayStatus")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.MeterCurrentSlabRate)
                    .HasColumnName("MeterCurrent_SlabRate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MeterLastCommunication)
                    .HasColumnName("Meter_LastCommunication")
                    .HasColumnType("datetime");

                entity.Property(e => e.MeterMode)
                    .HasColumnName("Meter_Mode")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.MeterVersion)
                    .HasColumnName("Meter_Version")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("Payment_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("Payment_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PresentDataCommunication)
                    .HasColumnName("PresentData_Communication")
                    .HasColumnType("datetime");

                entity.Property(e => e.RawReadDateTime)
                    .HasColumnName("RawRead_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalTampersCount).HasColumnName("Total_TampersCount");
            });

            modelBuilder.Entity<MeterRequestMaster>(entity =>
            {
                entity.HasKey(e => new { e.RequestId, e.CommandCode })
                    .HasName("PK_meter_request_master");

                entity.ToTable("Meter_Request_Master");

                entity.Property(e => e.RequestId)
                    .HasColumnName("Request_Id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CommandCode)
                    .HasColumnName("Command_Code")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CommandName)
                    .IsRequired()
                    .HasColumnName("Command_Name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.InputField)
                    .HasColumnName("Input_Field")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OutputField)
                    .HasColumnName("Output_Field")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PriorityType).HasColumnName("Priority_Type");

                entity.Property(e => e.RequestProcessDateTime)
                    .HasColumnName("RequestProcess_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequestSetDateTime)
                    .HasColumnName("RequestSet_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequestType)
                    .HasColumnName("Request_Type")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduleTime)
                    .HasColumnName("Schedule_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MeterRequestTranslog>(entity =>
            {
                entity.HasKey(e => new { e.RequestId, e.CommandCode })
                    .HasName("PK_meter_request_translog");

                entity.ToTable("Meter_Request_Translog");

                entity.Property(e => e.RequestId)
                    .HasColumnName("Request_Id")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CommandCode)
                    .HasColumnName("Command_Code")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CommandName)
                    .IsRequired()
                    .HasColumnName("Command_Name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PriorityType).HasColumnName("Priority_Type");

                entity.Property(e => e.RequestProcessDateTime)
                    .HasColumnName("RequestProcess_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequestSetDateTime)
                    .HasColumnName("RequestSet_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequestType)
                    .HasColumnName("Request_Type")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduleTime)
                    .HasColumnName("Schedule_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MonthlyBillingData>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.BillingDate })
                    .HasName("monthly_billing_pk");

                entity.ToTable("Monthly_Billing_data");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("IND_mon_billing");

                entity.HasIndex(e => new { e.MeterNo, e.BillingDate })
                    .HasName("IND_mon_bill");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BillingDate)
                    .HasColumnName("Billing_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CumMdKVaImport).HasColumnName("CumMD_kVaImport");

                entity.Property(e => e.CumMdKWimport).HasColumnName("CumMD_kWImport");

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMd).HasColumnName("kVA_MD");

                entity.Property(e => e.KVaMdOccurTime)
                    .HasColumnName("kVA_MD_OccurTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT1)
                    .HasColumnName("kVA_MD_OccurTime_T1")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT2)
                    .HasColumnName("kVA_MD_OccurTime_T2")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT3)
                    .HasColumnName("kVA_MD_OccurTime_T3")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT4)
                    .HasColumnName("kVA_MD_OccurTime_T4")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT5)
                    .HasColumnName("kVA_MD_OccurTime_T5")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT6)
                    .HasColumnName("kVA_MD_OccurTime_T6")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT7)
                    .HasColumnName("kVA_MD_OccurTime_T7")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT8)
                    .HasColumnName("kVA_MD_OccurTime_T8")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdT1).HasColumnName("kVA_MD_T1");

                entity.Property(e => e.KVaMdT2).HasColumnName("kVA_MD_T2");

                entity.Property(e => e.KVaMdT3).HasColumnName("kVA_MD_T3");

                entity.Property(e => e.KVaMdT4).HasColumnName("kVA_MD_T4");

                entity.Property(e => e.KVaMdT5).HasColumnName("kVA_MD_T5");

                entity.Property(e => e.KVaMdT6).HasColumnName("kVA_MD_T6");

                entity.Property(e => e.KVaMdT7).HasColumnName("kVA_MD_T7");

                entity.Property(e => e.KVaMdT8).HasColumnName("kVA_MD_T8");

                entity.Property(e => e.KVahExport).HasColumnName("kVah_Export");

                entity.Property(e => e.KVahExportT1).HasColumnName("kVah_Export_T1");

                entity.Property(e => e.KVahExportT2).HasColumnName("kVah_Export_T2");

                entity.Property(e => e.KVahExportT3).HasColumnName("kVah_Export_T3");

                entity.Property(e => e.KVahExportT4).HasColumnName("kVah_Export_T4");

                entity.Property(e => e.KVahExportT5).HasColumnName("kVah_Export_T5");

                entity.Property(e => e.KVahExportT6).HasColumnName("kVah_Export_T6");

                entity.Property(e => e.KVahExportT7).HasColumnName("kVah_Export_T7");

                entity.Property(e => e.KVahExportT8).HasColumnName("kVah_Export_T8");

                entity.Property(e => e.KVahImport).HasColumnName("kVah_Import");

                entity.Property(e => e.KVahImportT1).HasColumnName("kVah_Import_T1");

                entity.Property(e => e.KVahImportT2).HasColumnName("kVah_Import_T2");

                entity.Property(e => e.KVahImportT3).HasColumnName("kVah_Import_T3");

                entity.Property(e => e.KVahImportT4).HasColumnName("kVah_Import_T4");

                entity.Property(e => e.KVahImportT5).HasColumnName("kVah_Import_T5");

                entity.Property(e => e.KVahImportT6).HasColumnName("kVah_Import_T6");

                entity.Property(e => e.KVahImportT7).HasColumnName("kVah_Import_T7");

                entity.Property(e => e.KVahImportT8).HasColumnName("kVah_Import_T8");

                entity.Property(e => e.KVarhQ1).HasColumnName("kVarh_Q1");

                entity.Property(e => e.KVarhQ2).HasColumnName("kVarh_Q2");

                entity.Property(e => e.KVarhQ3).HasColumnName("kVarh_Q3");

                entity.Property(e => e.KVarhQ4).HasColumnName("kVarh_Q4");

                entity.Property(e => e.KWMd).HasColumnName("kW_MD");

                entity.Property(e => e.KWMdOccurTime)
                    .HasColumnName("kW_MD_OccurTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT1)
                    .HasColumnName("kW_MD_OccurTime_T1")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT2)
                    .HasColumnName("kW_MD_OccurTime_T2")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT3)
                    .HasColumnName("kW_MD_OccurTime_T3")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT4)
                    .HasColumnName("kW_MD_OccurTime_T4")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT5)
                    .HasColumnName("kW_MD_OccurTime_T5")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT6)
                    .HasColumnName("kW_MD_OccurTime_T6")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT7)
                    .HasColumnName("kW_MD_OccurTime_T7")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT8)
                    .HasColumnName("kW_MD_OccurTime_T8")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdT1).HasColumnName("kW_MD_T1");

                entity.Property(e => e.KWMdT2).HasColumnName("kW_MD_T2");

                entity.Property(e => e.KWMdT3).HasColumnName("kW_MD_T3");

                entity.Property(e => e.KWMdT4).HasColumnName("kW_MD_T4");

                entity.Property(e => e.KWMdT5).HasColumnName("kW_MD_T5");

                entity.Property(e => e.KWMdT6).HasColumnName("kW_MD_T6");

                entity.Property(e => e.KWMdT7).HasColumnName("kW_MD_T7");

                entity.Property(e => e.KWMdT8).HasColumnName("kW_MD_T8");

                entity.Property(e => e.KwhExport).HasColumnName("KWh_Export");

                entity.Property(e => e.KwhExportT1).HasColumnName("KWh_Export_T1");

                entity.Property(e => e.KwhExportT2).HasColumnName("KWh_Export_T2");

                entity.Property(e => e.KwhExportT3).HasColumnName("KWh_Export_T3");

                entity.Property(e => e.KwhExportT4).HasColumnName("KWh_Export_T4");

                entity.Property(e => e.KwhExportT5).HasColumnName("KWh_Export_T5");

                entity.Property(e => e.KwhExportT6).HasColumnName("KWh_Export_T6");

                entity.Property(e => e.KwhExportT7).HasColumnName("KWh_Export_T7");

                entity.Property(e => e.KwhExportT8).HasColumnName("KWh_Export_T8");

                entity.Property(e => e.KwhImport).HasColumnName("KWh_Import");

                entity.Property(e => e.KwhImportT1).HasColumnName("KWh_Import_T1");

                entity.Property(e => e.KwhImportT2).HasColumnName("KWh_Import_T2");

                entity.Property(e => e.KwhImportT3).HasColumnName("KWh_Import_T3");

                entity.Property(e => e.KwhImportT4).HasColumnName("KWh_Import_T4");

                entity.Property(e => e.KwhImportT5).HasColumnName("KWh_Import_T5");

                entity.Property(e => e.KwhImportT6).HasColumnName("KWh_Import_T6");

                entity.Property(e => e.KwhImportT7).HasColumnName("KWh_Import_T7");

                entity.Property(e => e.KwhImportT8).HasColumnName("KWh_Import_T8");

                entity.Property(e => e.PowerOnDuration)
                    .HasColumnName("Power_On_Duration")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TamperCount).HasColumnName("Tamper_Count");
            });

            modelBuilder.Entity<NavBar>(entity =>
            {
                entity.ToTable("Nav_bar");

                entity.Property(e => e.NavBarId).HasColumnName("NavBar_Id");

                entity.Property(e => e.ActionName)
                    .HasColumnName("Action_Name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Area)
                    .HasColumnName("AREA")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ControllerName)
                    .HasColumnName("Controller_Name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Haschild)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImageClass)
                    .HasColumnName("Image_Class")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IsParent)
                    .HasColumnName("Is_Parent")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleName)
                    .HasColumnName("Module_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("Parent_Id");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.NavBar)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Nav_bar__Role_Id__3E1D39E1");
            });

            modelBuilder.Entity<PrepaidConsumerBillingHistory>(entity =>
            {
                entity.HasKey(e => e.MeterNo);

                entity.ToTable("Prepaid_ConsumerBillingHistory");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("ind_pre_conbill");

                entity.HasIndex(e => new { e.MeterNo, e.CalculatedDate })
                    .HasName("ind_pre_con_bill");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApproximateDays).HasColumnName("Approximate_Days");

                entity.Property(e => e.AvgUnits).HasColumnName("Avg_units");

                entity.Property(e => e.BillingDate)
                    .HasColumnName("Billing_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CalculatedDate)
                    .HasColumnName("Calculated_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CcCharges).HasColumnName("CC_Charges");

                entity.Property(e => e.ClosedBalance).HasColumnName("Closed_Balance");

                entity.Property(e => e.CreditJe).HasColumnName("Credit_Je");

                entity.Property(e => e.CumRcAmount).HasColumnName("Cum_RC_Amount");

                entity.Property(e => e.DebitJe).HasColumnName("Debit_Je");

                entity.Property(e => e.EdChrages).HasColumnName("ED_Chrages");

                entity.Property(e => e.EnergyCharges).HasColumnName("Energy_Charges");

                entity.Property(e => e.FixedCharges).HasColumnName("Fixed_Charges");

                entity.Property(e => e.KvahOpenReading).HasColumnName("Kvah_Open_Reading");

                entity.Property(e => e.KvahPresentReading).HasColumnName("Kvah_Present_Reading");

                entity.Property(e => e.MdKva).HasColumnName("Md_Kva");

                entity.Property(e => e.MdKw).HasColumnName("Md_Kw");

                entity.Property(e => e.Mf).HasColumnName("MF");

                entity.Property(e => e.OpenBalance).HasColumnName("Open_Balance");

                entity.Property(e => e.OpenReading).HasColumnName("Open_Reading");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PresentReading).HasColumnName("Present_Reading");

                entity.Property(e => e.SignalStrength)
                    .HasColumnName("Signal_Strength")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmt).HasColumnName("Total_Amt");

                entity.Property(e => e.TotalCollamt).HasColumnName("Total_Collamt");
            });

            modelBuilder.Entity<PrepaidCurInstantaneous>(entity =>
            {
                entity.HasKey(e => e.MeterNo)
                    .HasName("Cur_Inst");

                entity.ToTable("Prepaid_Cur_Instantaneous");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("ind_pre_cur");

                entity.HasIndex(e => new { e.MeterNo, e.MeterReadDate })
                    .HasName("ind_precur");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.KvahReading)
                    .HasColumnName("Kvah_Reading")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.KwhReading)
                    .HasColumnName("Kwh_Reading")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MdKva)
                    .HasColumnName("Md_Kva")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MdKw)
                    .HasColumnName("Md_Kw")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MeterReadDate)
                    .HasColumnName("Meter_ReadDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SignalStrength)
                    .HasColumnName("Signal_Strength")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrepaidDailyBillingHistory>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.BillingDate, e.CalculatedDate })
                    .HasName("Pk_Prepaid_DailyBillingHistory111");

                entity.ToTable("Prepaid_DailyBillingHistory");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("ind_pre_dail_bill");

                entity.HasIndex(e => new { e.MeterNo, e.BillingDate })
                    .HasName("ind_pre_daily_bill");

                entity.HasIndex(e => new { e.MeterNo, e.CalculatedDate })
                    .HasName("ind_pre_dailybill");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BillingDate)
                    .HasColumnName("Billing_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CalculatedDate)
                    .HasColumnName("Calculated_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApproximateDays).HasColumnName("Approximate_Days");

                entity.Property(e => e.AvgUnits).HasColumnName("Avg_units");

                entity.Property(e => e.CcCharges).HasColumnName("CC_Charges");

                entity.Property(e => e.ClosedBalance).HasColumnName("Closed_Balance");

                entity.Property(e => e.CreditJe).HasColumnName("Credit_Je");

                entity.Property(e => e.CumRcAmount).HasColumnName("Cum_RC_Amount");

                entity.Property(e => e.DebitJe).HasColumnName("Debit_Je");

                entity.Property(e => e.EdCharges).HasColumnName("ED_Charges");

                entity.Property(e => e.EnergyCharges).HasColumnName("Energy_Charges");

                entity.Property(e => e.FixedCharges).HasColumnName("Fixed_Charges");

                entity.Property(e => e.KvahOpenReading).HasColumnName("Kvah_Open_Reading");

                entity.Property(e => e.KvahPresentReading).HasColumnName("Kvah_Present_Reading");

                entity.Property(e => e.MdKva).HasColumnName("Md_Kva");

                entity.Property(e => e.MdKw).HasColumnName("Md_Kw");

                entity.Property(e => e.Mf).HasColumnName("MF");

                entity.Property(e => e.OpenBalance).HasColumnName("Open_Balance");

                entity.Property(e => e.OpenReading).HasColumnName("Open_Reading");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PresentReading).HasColumnName("Present_Reading");

                entity.Property(e => e.SignalStrength)
                    .HasColumnName("Signal_Strength")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmt).HasColumnName("Total_Amt");

                entity.Property(e => e.TotalCollamt).HasColumnName("Total_Collamt");
            });

            modelBuilder.Entity<PrepaidLedger>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.BillingDate })
                    .HasName("PK_ledger");

                entity.ToTable("Prepaid_Ledger");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BillingDate)
                    .HasColumnName("Billing_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApproximateDays).HasColumnName("Approximate_Days");

                entity.Property(e => e.AvgUnits).HasColumnName("Avg_units");

                entity.Property(e => e.CalculatedDate)
                    .HasColumnName("Calculated_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CcCharges).HasColumnName("CC_Charges");

                entity.Property(e => e.ClosedBalance).HasColumnName("Closed_Balance");

                entity.Property(e => e.CreditJe).HasColumnName("Credit_Je");

                entity.Property(e => e.CumRcAmount).HasColumnName("Cum_RC_Amount");

                entity.Property(e => e.DebitJe).HasColumnName("Debit_Je");

                entity.Property(e => e.EdCharges).HasColumnName("ED_Charges");

                entity.Property(e => e.EnergyCharges).HasColumnName("Energy_Charges");

                entity.Property(e => e.FixedCharges).HasColumnName("Fixed_Charges");

                entity.Property(e => e.KvahOpenReading).HasColumnName("Kvah_Open_Reading");

                entity.Property(e => e.KvahPresentReading).HasColumnName("Kvah_Present_Reading");

                entity.Property(e => e.MdKva).HasColumnName("Md_Kva");

                entity.Property(e => e.MdKw).HasColumnName("Md_Kw");

                entity.Property(e => e.Mf).HasColumnName("MF");

                entity.Property(e => e.MinCharges).HasColumnName("MIN_Charges");

                entity.Property(e => e.OpenBalance).HasColumnName("Open_Balance");

                entity.Property(e => e.OpenReading).HasColumnName("Open_Reading");

                entity.Property(e => e.PresentReading).HasColumnName("Present_Reading");

                entity.Property(e => e.TotalAmt).HasColumnName("Total_Amt");

                entity.Property(e => e.TotalCollamt).HasColumnName("Total_Collamt");
            });

            modelBuilder.Entity<PrepaidMeterLatestDetails>(entity =>
            {
                entity.HasKey(e => e.MeterNo)
                    .HasName("PK__Prepaid___11F8EA821EA48E88");

                entity.ToTable("Prepaid_MeterLatestDetails");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BalanceAmt).HasColumnName("Balance_Amt");

                entity.Property(e => e.ConsumptionUnits).HasColumnName("Consumption_Units");

                entity.Property(e => e.CreditLimitDateTime)
                    .HasColumnName("creditLimit_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MeterReadDate)
                    .HasColumnName("Meter_ReadDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PresentReading).HasColumnName("Present_Reading");

                entity.Property(e => e.RelayStatus)
                    .HasColumnName("Relay_Status")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SlabRate)
                    .HasColumnName("Slab_Rate")
                    .HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<RealtimeTamperMaster>(entity =>
            {
                entity.HasKey(e => e.TamperCode)
                    .HasName("PK__Realtime__D5A06B767C4F7684");

                entity.ToTable("Realtime_Tamper_Master");

                entity.Property(e => e.TamperCode)
                    .HasColumnName("Tamper_code")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AlarmCode)
                    .HasColumnName("Alarm_code")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AlarmDescription)
                    .HasColumnName("Alarm_description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AlarmStatus)
                    .HasColumnName("Alarm_status")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CcEventId)
                    .HasColumnName("Cc_Event_Id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TamperDescription)
                    .HasColumnName("Tamper_description")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TariffunitsMaster>(entity =>
            {
                entity.HasKey(e => new { e.Category, e.SubCategory, e.UnitsCat })
                    .HasName("PK_UNITS_MASTER");

                entity.ToTable("Tariffunits_Master");

                entity.Property(e => e.SubCategory).HasColumnName("Sub_Category");

                entity.Property(e => e.UnitsCat).HasColumnName("Units_Cat");

                entity.Property(e => e.LowerBound).HasColumnName("Lower_Bound");

                entity.Property(e => e.LowerLimit).HasColumnName("Lower_Limit");

                entity.Property(e => e.SlabEnddate)
                    .HasColumnName("Slab_Enddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SlabStartdate)
                    .HasColumnName("Slab_Startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Slno).ValueGeneratedOnAdd();

                entity.Property(e => e.SublowerLimit).HasColumnName("Sublower_Limit");

                entity.Property(e => e.SubupperLimit).HasColumnName("Subupper_Limit");

                entity.Property(e => e.UnitRate).HasColumnName("Unit_Rate");

                entity.Property(e => e.UpperBound).HasColumnName("Upper_Bound");

                entity.Property(e => e.UpperLimit).HasColumnName("Upper_Limit");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EmployeeId, e.UserLoginId })
                    .HasName("PK_User_master");

                entity.ToTable("User_Master");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("Employee_Id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserLoginId)
                    .HasColumnName("User_LoginId")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CellPhone)
                    .HasColumnName("Cell_phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_By")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnName("Creation_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Department)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("Email_Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasColumnName("Full_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OfficeAddress)
                    .HasColumnName("Office_Address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OfficeLandline)
                    .HasColumnName("Office_Landline")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.ScopeAccessLevel)
                    .HasColumnName("SCope_AccessLevel")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ScopeAccessValueId).HasColumnName("Scope_AccessValueId");

                entity.Property(e => e.Sms)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatus).HasColumnName("User_Status");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserMaster)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Mast__Role___46B27FE2");

                entity.HasOne(d => d.ScopeAccessValue)
                    .WithMany(p => p.UserMaster)
                    .HasForeignKey(d => d.ScopeAccessValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Mast__Scope__47A6A41B");
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.ToTable("User_Token");

                entity.Property(e => e.UserTokenId).HasColumnName("UserToken_Id");

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasColumnName("Client_Id")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpiryTime)
                    .HasColumnName("Expiry_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnName("Last_ModifiedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });
           
            modelBuilder.Entity<XmlFileMaster>(entity =>
            {
                entity.HasKey(e => e.MeterFileName)
                    .HasName("PK__Xml_file__01D7BBC147DBAE45");

                entity.ToTable("Xml_file_master");

                entity.Property(e => e.MeterFileName)
                    .HasColumnName("Meter_file_Name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BillingData)
                    .HasColumnName("Billing_Data")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralData)
                    .HasColumnName("General_Data")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HealthData)
                    .HasColumnName("Health_Data")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InstantData)
                    .HasColumnName("Instant_Data")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LoadsurveyData)
                    .HasColumnName("Loadsurvey_Data")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MeterReadDate)
                    .HasColumnName("Meter_Read_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.MidnightData)
                    .HasColumnName("Midnight_Data")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModemManufacturername)
                    .HasColumnName("Modem_Manufacturername")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TamperData)
                    .HasColumnName("Tamper_Data")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TranscationData)
                    .HasColumnName("Transcation_Data")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<ZeroHistoryBillingData>(entity =>
            {
                entity.HasKey(e => new { e.MeterNo, e.BillingDatetime })
                    .HasName("zero_billing_pk");

                entity.ToTable("ZeroHistory_Billing_data");

                entity.HasIndex(e => e.MeterNo)
                    .HasName("IND_zero_billing");

                entity.Property(e => e.MeterNo)
                    .HasColumnName("Meter_No")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BillingDatetime)
                    .HasColumnName("Billing_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.BillingDate)
                    .HasColumnName("Billing_Date")
                    .HasColumnType("date");

                entity.Property(e => e.CumMdKVaImport).HasColumnName("CumMD_kVaImport");

                entity.Property(e => e.CumMdKWimport).HasColumnName("CumMD_kWImport");

                entity.Property(e => e.InsertedDate)
                    .HasColumnName("Inserted_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMd).HasColumnName("kVA_MD");

                entity.Property(e => e.KVaMdOccurTime)
                    .HasColumnName("kVA_MD_OccurTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT1)
                    .HasColumnName("kVA_MD_OccurTime_T1")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT2)
                    .HasColumnName("kVA_MD_OccurTime_T2")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT3)
                    .HasColumnName("kVA_MD_OccurTime_T3")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT4)
                    .HasColumnName("kVA_MD_OccurTime_T4")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT5)
                    .HasColumnName("kVA_MD_OccurTime_T5")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT6)
                    .HasColumnName("kVA_MD_OccurTime_T6")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT7)
                    .HasColumnName("kVA_MD_OccurTime_T7")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdOccurTimeT8)
                    .HasColumnName("kVA_MD_OccurTime_T8")
                    .HasColumnType("datetime");

                entity.Property(e => e.KVaMdT1).HasColumnName("kVA_MD_T1");

                entity.Property(e => e.KVaMdT2).HasColumnName("kVA_MD_T2");

                entity.Property(e => e.KVaMdT3).HasColumnName("kVA_MD_T3");

                entity.Property(e => e.KVaMdT4).HasColumnName("kVA_MD_T4");

                entity.Property(e => e.KVaMdT5).HasColumnName("kVA_MD_T5");

                entity.Property(e => e.KVaMdT6).HasColumnName("kVA_MD_T6");

                entity.Property(e => e.KVaMdT7).HasColumnName("kVA_MD_T7");

                entity.Property(e => e.KVaMdT8).HasColumnName("kVA_MD_T8");

                entity.Property(e => e.KVahExport).HasColumnName("kVah_Export");

                entity.Property(e => e.KVahExportT1).HasColumnName("kVah_Export_T1");

                entity.Property(e => e.KVahExportT2).HasColumnName("kVah_Export_T2");

                entity.Property(e => e.KVahExportT3).HasColumnName("kVah_Export_T3");

                entity.Property(e => e.KVahExportT4).HasColumnName("kVah_Export_T4");

                entity.Property(e => e.KVahExportT5).HasColumnName("kVah_Export_T5");

                entity.Property(e => e.KVahExportT6).HasColumnName("kVah_Export_T6");

                entity.Property(e => e.KVahExportT7).HasColumnName("kVah_Export_T7");

                entity.Property(e => e.KVahExportT8).HasColumnName("kVah_Export_T8");

                entity.Property(e => e.KVahImport).HasColumnName("kVah_Import");

                entity.Property(e => e.KVahImportT1).HasColumnName("kVah_Import_T1");

                entity.Property(e => e.KVahImportT2).HasColumnName("kVah_Import_T2");

                entity.Property(e => e.KVahImportT3).HasColumnName("kVah_Import_T3");

                entity.Property(e => e.KVahImportT4).HasColumnName("kVah_Import_T4");

                entity.Property(e => e.KVahImportT5).HasColumnName("kVah_Import_T5");

                entity.Property(e => e.KVahImportT6).HasColumnName("kVah_Import_T6");

                entity.Property(e => e.KVahImportT7).HasColumnName("kVah_Import_T7");

                entity.Property(e => e.KVahImportT8).HasColumnName("kVah_Import_T8");

                entity.Property(e => e.KVarhQ1).HasColumnName("kVarh_Q1");

                entity.Property(e => e.KVarhQ2).HasColumnName("kVarh_Q2");

                entity.Property(e => e.KVarhQ3).HasColumnName("kVarh_Q3");

                entity.Property(e => e.KVarhQ4).HasColumnName("kVarh_Q4");

                entity.Property(e => e.KWMd).HasColumnName("kW_MD");

                entity.Property(e => e.KWMdOccurTime)
                    .HasColumnName("kW_MD_OccurTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT1)
                    .HasColumnName("kW_MD_OccurTime_T1")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT2)
                    .HasColumnName("kW_MD_OccurTime_T2")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT3)
                    .HasColumnName("kW_MD_OccurTime_T3")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT4)
                    .HasColumnName("kW_MD_OccurTime_T4")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT5)
                    .HasColumnName("kW_MD_OccurTime_T5")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT6)
                    .HasColumnName("kW_MD_OccurTime_T6")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT7)
                    .HasColumnName("kW_MD_OccurTime_T7")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdOccurTimeT8)
                    .HasColumnName("kW_MD_OccurTime_T8")
                    .HasColumnType("datetime");

                entity.Property(e => e.KWMdT1).HasColumnName("kW_MD_T1");

                entity.Property(e => e.KWMdT2).HasColumnName("kW_MD_T2");

                entity.Property(e => e.KWMdT3).HasColumnName("kW_MD_T3");

                entity.Property(e => e.KWMdT4).HasColumnName("kW_MD_T4");

                entity.Property(e => e.KWMdT5).HasColumnName("kW_MD_T5");

                entity.Property(e => e.KWMdT6).HasColumnName("kW_MD_T6");

                entity.Property(e => e.KWMdT7).HasColumnName("kW_MD_T7");

                entity.Property(e => e.KWMdT8).HasColumnName("kW_MD_T8");

                entity.Property(e => e.KwhExport).HasColumnName("KWh_Export");

                entity.Property(e => e.KwhExportT1).HasColumnName("KWh_Export_T1");

                entity.Property(e => e.KwhExportT2).HasColumnName("KWh_Export_T2");

                entity.Property(e => e.KwhExportT3).HasColumnName("KWh_Export_T3");

                entity.Property(e => e.KwhExportT4).HasColumnName("KWh_Export_T4");

                entity.Property(e => e.KwhExportT5).HasColumnName("KWh_Export_T5");

                entity.Property(e => e.KwhExportT6).HasColumnName("KWh_Export_T6");

                entity.Property(e => e.KwhExportT7).HasColumnName("KWh_Export_T7");

                entity.Property(e => e.KwhExportT8).HasColumnName("KWh_Export_T8");

                entity.Property(e => e.KwhImport).HasColumnName("KWh_Import");

                entity.Property(e => e.KwhImportT1).HasColumnName("KWh_Import_T1");

                entity.Property(e => e.KwhImportT2).HasColumnName("KWh_Import_T2");

                entity.Property(e => e.KwhImportT3).HasColumnName("KWh_Import_T3");

                entity.Property(e => e.KwhImportT4).HasColumnName("KWh_Import_T4");

                entity.Property(e => e.KwhImportT5).HasColumnName("KWh_Import_T5");

                entity.Property(e => e.KwhImportT6).HasColumnName("KWh_Import_T6");

                entity.Property(e => e.KwhImportT7).HasColumnName("KWh_Import_T7");

                entity.Property(e => e.KwhImportT8).HasColumnName("KWh_Import_T8");

                entity.Property(e => e.PowerOnDuration)
                    .HasColumnName("Power_On_Duration")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TamperCount).HasColumnName("Tamper_Count");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }    
}
