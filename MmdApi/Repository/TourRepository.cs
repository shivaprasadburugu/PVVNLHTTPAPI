using MdmApi.DataContext;
using MdmApi.Helpers;
using MdmApi.Models;
using MdmApi.Web.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly ContextDb _context;
        private readonly ServiceConfiguration _appSettings;
        private readonly IDatabaseSecureConnectionHelperRepository _databaseSecureConnectionHelper;

        public TourRepository(ContextDb context,
           IOptions<ServiceConfiguration> settings, IDatabaseSecureConnectionHelperRepository databaseSecureConnectionHelper)
        {
            _context = context;
            _appSettings = settings.Value;
            _databaseSecureConnectionHelper = databaseSecureConnectionHelper;
        }
        public DataSet InsertTourAdvance(TourModel1 tourModel)
        {
            DateTime parseddate = DateTime.ParseExact(tourModel.tour_fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            DateTime parseddate1 = DateTime.ParseExact(tourModel.tour_todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string tourfromdate = parseddate.ToString("yyyy-MM-dd");
            string tourtodate = parseddate1.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("empid", tourModel.empid));
                lstParams.Add(new KeyValuePair<string, object>("tour_formdate", tourfromdate));
                lstParams.Add(new KeyValuePair<string, object>("tour_todate", tourtodate));
                lstParams.Add(new KeyValuePair<string, object>("purposes", tourModel.purposes));
                lstParams.Add(new KeyValuePair<string, object>("created_by", tourModel.CreatedBy));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.touradvance_insert[0], StoredProcedure.touradvance_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet UpdateTourAdvance(TourModel1 tourModel)
        {
            DateTime parseddate = DateTime.ParseExact(tourModel.tour_fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            DateTime parseddate1 = DateTime.ParseExact(tourModel.tour_todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            string tourfromdate = parseddate.ToString("yyyy-MM-dd");
            string tourtodate = parseddate1.ToString("yyyy-MM-dd");
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("tourid", tourModel.tourid));
                lstParams.Add(new KeyValuePair<string, object>("empid", tourModel.empid));
                //lstParams.Add(new KeyValuePair<string, object>("advance_amount", tourModel.advance_amount));
                lstParams.Add(new KeyValuePair<string, object>("tour_fromdate", tourfromdate));
                lstParams.Add(new KeyValuePair<string, object>("tour_todate", tourtodate));
                //lstParams.Add(new KeyValuePair<string, object>("places", tourModel.places));
                lstParams.Add(new KeyValuePair<string, object>("purposes", tourModel.purposes));
                //lstParams.Add(new KeyValuePair<string, object>("day", tourModel.days));
                // lstParams.Add(new KeyValuePair<string, object>("ages", tourModel.age));
                lstParams.Add(new KeyValuePair<string, object>("created_by", tourModel.CreatedBy));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.touradvance_update[0], StoredProcedure.touradvance_update[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet FetchTourAdvance(TourModel tourModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("tourid", tourModel.tourid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.touradvance_fetch[0], StoredProcedure.touradvance_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet DeleteTourAdvance(TourModel1 tourModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("tourid", tourModel.tourid));
                lstParams.Add(new KeyValuePair<string, object>("created_by", tourModel.CreatedBy));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.touradvance_delete[0], StoredProcedure.touradvance_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetTourAdvanceDetails(EmployeeMonthReport employeeMonthReport)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(employeeMonthReport.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromDate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(employeeMonthReport.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("from_date", fromDate));
                lstParams.Add(new KeyValuePair<string, object>("to_date", todate));
                lstParams.Add(new KeyValuePair<string, object>("depart_name", employeeMonthReport.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", employeeMonthReport.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.touradvance_details[0], StoredProcedure.touradvance_details[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet InsertUpdateTourSettlement(TourSettlement tourSettlement)
        {
           

            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(tourSettlement.touradvance_id)));
                lstParams.Add(new KeyValuePair<string, object>("journey_amount", Convert.ToDouble(tourSettlement.journey_amount)));
                lstParams.Add(new KeyValuePair<string, object>("hotelstay_amount", Convert.ToDouble(tourSettlement.hotelstay_amount)));
                lstParams.Add(new KeyValuePair<string, object>("local_convenyance", Convert.ToDouble(tourSettlement.local_convenyance)));
                lstParams.Add(new KeyValuePair<string, object>("misc_expense", Convert.ToDouble(tourSettlement.misc_expense)));
                lstParams.Add(new KeyValuePair<string, object>("grand_total", Convert.ToDouble(tourSettlement.grand_total)));
                lstParams.Add(new KeyValuePair<string, object>("balances", Convert.ToDouble(tourSettlement.balances)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.tourdetails_insert[0], StoredProcedure.tourdetails_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
 
        public DataSet FetchtourDetails(TourDetailsModel tourDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("adv_id", Convert.ToInt32(tourDetailsModel.adv_id)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.tourdetails_fetch[0], StoredProcedure.tourdetails_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchHotelstayDetails(TourDetailsModel tourDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("adv_id", Convert.ToInt32(tourDetailsModel.adv_id)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hotelstay_fetch[0], StoredProcedure.hotelstay_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchconvenyanceDetails(TourDetailsModel tourDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("adv_id", Convert.ToInt32(tourDetailsModel.adv_id)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.convenyancedetails_fetch[0], StoredProcedure.convenyancedetails_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet FetchJourneyDetails(TourDetailsModel tourDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("adv_id", Convert.ToInt32(tourDetailsModel.adv_id)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.journeydetails_fetch[0], StoredProcedure.journeydetails_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //FetchMiscelianeousDetails
        public DataSet FetchMiscelianeousDetails(TourDetailsModel tourDetailsModel)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("adv_id", Convert.ToInt32(tourDetailsModel.adv_id)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.miscelianeousexpensesdetails_fetch[0], StoredProcedure.miscelianeousexpensesdetails_fetch[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<JourneyDetailsModel> InsertJourneyDetails(List<JourneyDetailsModel> journeyDetailsRequest)
        {
            DeleteJourneydetails(journeyDetailsRequest.FirstOrDefault());
            List<JourneyDetailsModel> targetList = journeyDetailsRequest.Select(item2 =>
                new JourneyDetailsModel
                {
                    touradvanceid = item2.touradvanceid,
                    source = item2.source,
                    departure = item2.departure,
                    destination = item2.destination,
                    arrivaldatetime = item2.arrivaldatetime,
                    modeoftravel = item2.modeoftravel,
                    fare = item2.fare,
                    journeyda = item2.journeyda,
                    totalamount = item2.totalamount,
                    filepath = item2.filepath,

                }).ToList();

            for (int i = 0; i < targetList.Count; i++)
            {
                InsertJourneydetails(targetList[i]);
            }

            return targetList;
        }
        public DataSet InsertJourneydetails(JourneyDetailsModel journeyDetailsRequest)
        {
            try
            {
                
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();               
                string departureDateTime = journeyDetailsRequest.departure.ToString("yyyy-MM-dd HH:mm:ss");
                string arrivalDateTime = journeyDetailsRequest.arrivaldatetime.ToString("yyyy-MM-dd HH:mm:ss");
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(journeyDetailsRequest.touradvanceid)));
                lstParams.Add(new KeyValuePair<string, object>("source1", journeyDetailsRequest.source));       
                lstParams.Add(new KeyValuePair<string, object>("departuredatetime", departureDateTime));
                lstParams.Add(new KeyValuePair<string, object>("destination1", journeyDetailsRequest.destination));      
                lstParams.Add(new KeyValuePair<string, object>("arrival_datetime", arrivalDateTime));
                lstParams.Add(new KeyValuePair<string, object>("modeof_travel", journeyDetailsRequest.modeoftravel));
                lstParams.Add(new KeyValuePair<string, object>("fare1", Convert.ToDouble(journeyDetailsRequest.fare)));
                lstParams.Add(new KeyValuePair<string, object>("journey_da", Convert.ToDouble(journeyDetailsRequest.journeyda)));
                lstParams.Add(new KeyValuePair<string, object>("totalamount4", Convert.ToDouble(journeyDetailsRequest.totalamount)));
                lstParams.Add(new KeyValuePair<string, object>("file_path", journeyDetailsRequest.filepath));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.journeydetails_insert[0], StoredProcedure.journeydetails_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DeleteJourneydetails(JourneyDetailsModel journeyDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", journeyDetailsRequest.touradvanceid));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.journeydetails_delete[0], StoredProcedure.journeydetails_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //InsertHotelstayDetails
        public List<HotelStayDetailsModel> InsertHotelstayDetails(List<HotelStayDetailsModel> hotelstayDetailsRequest)
        {
            DeleteHotelstayDetails(hotelstayDetailsRequest.FirstOrDefault());
            List<HotelStayDetailsModel> targetList = hotelstayDetailsRequest.Select(item2 =>
                new HotelStayDetailsModel
                {
                    touradvanceid = item2.touradvanceid,
                    place = item2.place,
                    fromdate = item2.fromdate,
                    todate = item2.todate,
                    amount = item2.amount,
                    da = item2.da,                  
                    totalamount = item2.totalamount,
                    filepath = item2.filepath,
                }).ToList();

            for (int i = 0; i < targetList.Count; i++)
            {
                InsertHoteldetails(targetList[i]);
            }
            return targetList;
        }
        public DataSet InsertHoteldetails(HotelStayDetailsModel hotelstayDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                DateTime parseddate4 = DateTime.ParseExact(hotelstayDetailsRequest.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                DateTime parseddate5 = DateTime.ParseExact(hotelstayDetailsRequest.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string Departuredatetime = parseddate4.ToString("yyyy-MM-dd");
                string Arrivaldatetime = parseddate5.ToString("yyyy-MM-dd");
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(hotelstayDetailsRequest.touradvanceid)));
                lstParams.Add(new KeyValuePair<string, object>("place1", hotelstayDetailsRequest.place));
                lstParams.Add(new KeyValuePair<string, object>("fromdate1", Departuredatetime));              
                lstParams.Add(new KeyValuePair<string, object>("todate1", Arrivaldatetime));           
                lstParams.Add(new KeyValuePair<string, object>("amount1", Convert.ToDouble(hotelstayDetailsRequest.amount)));
                lstParams.Add(new KeyValuePair<string, object>("daa", Convert.ToDouble(hotelstayDetailsRequest.da)));
                lstParams.Add(new KeyValuePair<string, object>("totalamount3", Convert.ToDouble(hotelstayDetailsRequest.totalamount)));
                lstParams.Add(new KeyValuePair<string, object>("file_path", hotelstayDetailsRequest.filepath));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hotelstay_insert[0], StoredProcedure.hotelstay_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DeleteHotelstayDetails(HotelStayDetailsModel hotelstayDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(hotelstayDetailsRequest.touradvanceid)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.hotelstay_delete[0], StoredProcedure.hotelstay_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ConvenyanceDetailsModel> InsertConvenyanceDetails(List<ConvenyanceDetailsModel> ConvenyanceDetailsRequest)
        {
            DeleteConvenyanceDetails(ConvenyanceDetailsRequest.FirstOrDefault());
            List<ConvenyanceDetailsModel> targetList = ConvenyanceDetailsRequest.Select(item2 =>
                new ConvenyanceDetailsModel
                {
                    touradvanceid = item2.touradvanceid,
                    date = item2.date,
                    fromplace = item2.fromplace,
                    toplace = item2.toplace,
                    modeoftransport = item2.modeoftransport,
                    totalamount = item2.totalamount,
                    filepath = item2.filepath,
                }).ToList();

            for (int i = 0; i < targetList.Count; i++)
            {
                InsertConvenyancedetails(targetList[i]);
            }
            return targetList;
        }
        public DataSet InsertConvenyancedetails(ConvenyanceDetailsModel ConvenyanceDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                DateTime parseddate4 = DateTime.ParseExact(ConvenyanceDetailsRequest.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);              
                string Datee = parseddate4.ToString("yyyy-MM-dd");
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(ConvenyanceDetailsRequest.touradvanceid)));             
                lstParams.Add(new KeyValuePair<string, object>("date2", Datee));
                lstParams.Add(new KeyValuePair<string, object>("fromplace1", ConvenyanceDetailsRequest.fromplace));
                lstParams.Add(new KeyValuePair<string, object>("toplace1", ConvenyanceDetailsRequest.toplace));
                lstParams.Add(new KeyValuePair<string, object>("modeof_transport", ConvenyanceDetailsRequest.modeoftransport));
                lstParams.Add(new KeyValuePair<string, object>("totalamount2", Convert.ToDouble(ConvenyanceDetailsRequest.totalamount)));
                lstParams.Add(new KeyValuePair<string, object>("file_path", ConvenyanceDetailsRequest.filepath));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.convenyancedetails_insert[0], StoredProcedure.convenyancedetails_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DeleteConvenyanceDetails(ConvenyanceDetailsModel ConvenyanceDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(ConvenyanceDetailsRequest.touradvanceid)));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.convenyancedetails_delete[0], StoredProcedure.convenyancedetails_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<MiscelianeousDetailsModel> InsertMiscelianeousDetails(List<MiscelianeousDetailsModel> MiscelianeousDetailsRequest)
        {
            DeleteMiscelianeousdetails(MiscelianeousDetailsRequest.FirstOrDefault());
            List<MiscelianeousDetailsModel> targetList = MiscelianeousDetailsRequest.Select(item2 =>
                new MiscelianeousDetailsModel
                {
                    touradvanceid = item2.touradvanceid,
                    date = item2.date,
                    fromplace = item2.fromplace,                   
                    totalamount = item2.totalamount,
                    filepath = item2.filepath,
                }).ToList();
            for (int i = 0; i < targetList.Count; i++)
            {
                InsertMiscelianeousdetails(targetList[i]);
            }
            return targetList;
        }
        public DataSet InsertMiscelianeousdetails(MiscelianeousDetailsModel MiscelianeousDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                DateTime parseddate4 = DateTime.ParseExact(MiscelianeousDetailsRequest.date, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string Datee = parseddate4.ToString("yyyy-MM-dd");
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(MiscelianeousDetailsRequest.touradvanceid)));
                lstParams.Add(new KeyValuePair<string, object>("date1", Datee));
                lstParams.Add(new KeyValuePair<string, object>("from_place", MiscelianeousDetailsRequest.fromplace));            
                lstParams.Add(new KeyValuePair<string, object>("totalamount1", Convert.ToDouble(MiscelianeousDetailsRequest.totalamount)));
                lstParams.Add(new KeyValuePair<string, object>("file_path", MiscelianeousDetailsRequest.filepath));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.miscelianeousexpensesdetails_insert[0], StoredProcedure.miscelianeousexpensesdetails_insert[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet DeleteMiscelianeousdetails(MiscelianeousDetailsModel MiscelianeousDetailsRequest)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();              
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", Convert.ToInt32(MiscelianeousDetailsRequest.touradvanceid)));                
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.miscelianeousexpensesdetails_delete[0], StoredProcedure.miscelianeousexpensesdetails_delete[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet EmployeeLeaveAcceptRejected(TourAdvanceStatus tourAdvanceStatus)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", tourAdvanceStatus.touradvanceid));
                lstParams.Add(new KeyValuePair<string, object>("status", tourAdvanceStatus.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.touradvance_accept_rejected[0], StoredProcedure.touradvance_accept_rejected[1], lstParams);
                return ds;
            }
            catch
            {
                return null;
            }
        }
        //EmployeeDetailsAcceptRejected

        public DataSet EmployeeDetailsAcceptRejected(TourAdvanceStatus tourAdvanceStatus)
        {
            try
            {
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("touradvance_id", tourAdvanceStatus.touradvanceid));
                lstParams.Add(new KeyValuePair<string, object>("status", tourAdvanceStatus.status));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.tourdetails_accept_rejected[0], StoredProcedure.tourdetails_accept_rejected[1], lstParams);
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public DataSet GetTourAdvanceDetailsPreview(EmployeeMonthReport employeeMonthReport)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(employeeMonthReport.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromDate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(employeeMonthReport.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("from_date", fromDate));
                lstParams.Add(new KeyValuePair<string, object>("to_date", todate));
                lstParams.Add(new KeyValuePair<string, object>("depart_name", employeeMonthReport.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", employeeMonthReport.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.touradvance_details_perview[0], StoredProcedure.touradvance_details_perview[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetTourAdvanceDetailsSettlement(EmployeeMonthReport employeeMonthReport)
        {
            try
            {
                DateTime parseddate = DateTime.ParseExact(employeeMonthReport.fromdate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string fromDate = parseddate.ToString("yyyy-MM-dd");
                DateTime parseddate1 = DateTime.ParseExact(employeeMonthReport.todate, new[] { "dd-MM-yyyy", "dd/MM/yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
                string todate = parseddate1.ToString("yyyy-MM-dd");
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("from_date", fromDate));
                lstParams.Add(new KeyValuePair<string, object>("to_date", todate));
                lstParams.Add(new KeyValuePair<string, object>("depart_name", employeeMonthReport.departmentname));
                lstParams.Add(new KeyValuePair<string, object>("level", employeeMonthReport.level));
                lstParams.Add(new KeyValuePair<string, object>("eid", employeeMonthReport.id));
                DataSet ds = _databaseSecureConnectionHelper.ExecuteAsDataSet(StoredProcedure.touradvance_details_settlement[0], StoredProcedure.touradvance_details_settlement[1], lstParams);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}