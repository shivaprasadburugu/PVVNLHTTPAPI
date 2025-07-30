using MdmApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
    public interface IMobileAppRepository
    {
        DataSet InsertMobileUser(MobileAppString mobileApp);

        //InsertMobileLogs
        DataSet InsertMobileLogs(MobileLog mobileLogs);

        DataSet MobileEmployeeDetails(string employeeid);

        DataSet MobileDashboardCounts(MobileAppString MobileApp);

        DataSet MobileEmployeeAbsentPresentCounts(MobileDasboardLogsString mobileDasboardLogs);
        //MobileTourAdvanceFromDateCount
        DataSet MobileTourAdvanceFromDateCount(MobileDasboardLogsString mobileDasboardLogs);
        DataSet MobileTourAdvanceDetails(string employeeid);

        DataSet MobileTourAdvanceInsert(TourModel tourModel);

        DataSet FetchMobileTourAdvance(int Tourid);

        DataSet FetchMobileEmployeeAttendanceOnclick(MobileLogs mobileLogs);
        DataSet FetchMobileEmployeeIntimeStatus(MobileLogs mobileLogs);
        DataSet FetchMobilePendingApprovals(MobileDasboardLogsString mobileLogs);
        DataSet FetchMobileLeaveOnclicks(MobileDasboardLogsString mobileDasboardLogs);
        DataSet FetchMobileEmployeeLocation(MobileDasboardLogsString mobileDasboardLogs);
        DataSet InsertMobileEmployeeLocation(MobileLocationString mobileLocation);
        //InsertJourneyDetails
        List<JourneyDetailsModel1> Mobile_InsertJourneyDetails(List<JourneyDetailsModel1> journeyDetailsRequest);
        //InsertHotelstayDetails
        List<HotelStayDetailsModel> Mobile_InsertHotelstayDetails(List<HotelStayDetailsModel> hotelstayDetailsRequest);
        List<ConvenyanceDetailsModel> Mobile_InsertConvenyanceDetails(List<ConvenyanceDetailsModel> ConvenyanceDetailsRequest);
        List<MiscelianeousDetailsModel> Mobile_InsertMiscelianeousDetails(List<MiscelianeousDetailsModel> MiscelianeousDetailsRequest);
        DataSet FetchMobileJourneyDetails(TourDetailsModel tourDetailsModel);
        DataSet DeleteMobile_Journeydetails(JourneyDetailsModel1 journeyDetailsRequest);
        DataSet DeleteMobileHotelstayDetails(HotelStayDetailsModel hotelstayDetailsRequest);
        DataSet DeleteMobileConvenyanceDetails(ConvenyanceDetailsModel ConvenyanceDetailsRequest);
        DataSet DeleteMobileMiscelianeousdetails(MiscelianeousDetailsModel MiscelianeousDetailsRequest);
        DataSet GetTotalTourDetails(TourDetailsModel tourDetailsModel);
        DataSet FetchMobileHotelStay(TourDetailsModel tourDetailsModel);
        DataSet FetchMobileConvenyanceDetails(TourDetailsModel tourDetailsModel);
        DataSet FetchMobileMiscelianeousexpensesDetails(TourDetailsModel tourDetailsModel);
        DataSet MobileAppUpdate();
    }
}
