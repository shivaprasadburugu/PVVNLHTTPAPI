using MdmApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Repository
{
    public interface ITourRepository
    {
        DataSet InsertTourAdvance(TourModel1 tourModel);

        DataSet GetTourAdvanceDetails(EmployeeMonthReport employeeMonthReport);
        DataSet UpdateTourAdvance(TourModel1 tourModel);

        DataSet FetchTourAdvance(TourModel tourModel);

        DataSet DeleteTourAdvance(TourModel1 tourModel);
        DataSet InsertUpdateTourSettlement(TourSettlement tourSettlement);
        DataSet FetchtourDetails(TourDetailsModel tourDetailsModel);
        DataSet FetchHotelstayDetails(TourDetailsModel tourDetailsModel);
        DataSet FetchconvenyanceDetails(TourDetailsModel tourDetailsModel);
        //FetchJourneyDetails
        DataSet FetchJourneyDetails(TourDetailsModel tourDetailsModel);
        //FetchMiscelianeousDetails
        DataSet FetchMiscelianeousDetails(TourDetailsModel tourDetailsModel);
        
        //InsertJourneyDetails
        
        List<JourneyDetailsModel> InsertJourneyDetails(List<JourneyDetailsModel> journeyDetailsRequest);
        //InsertHotelstayDetails
        List<HotelStayDetailsModel> InsertHotelstayDetails(List<HotelStayDetailsModel> hotelstayDetailsRequest);
        List<ConvenyanceDetailsModel> InsertConvenyanceDetails(List<ConvenyanceDetailsModel> ConvenyanceDetailsRequest);
        List<MiscelianeousDetailsModel> InsertMiscelianeousDetails(List<MiscelianeousDetailsModel> MiscelianeousDetailsRequest);
        DataSet EmployeeLeaveAcceptRejected(TourAdvanceStatus tourAdvanceStatus);
        //EmployeeDetailsAcceptRejected
        DataSet EmployeeDetailsAcceptRejected(TourAdvanceStatus tourAdvanceStatus);
        DataSet GetTourAdvanceDetailsPreview(EmployeeMonthReport employeeMonthReport);
        DataSet GetTourAdvanceDetailsSettlement(EmployeeMonthReport employeeMonthReport);

    }
}
