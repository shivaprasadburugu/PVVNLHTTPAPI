using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Models
{

    public class TourDetailsModel
    {
        [JsonProperty("adv_id")]
        public int adv_id { get; set; }
    }
    public class TourModel
    {

        [JsonProperty("tourid")]
        public int tourid { get; set; }

        [JsonProperty("empid")]
        public string empid { get; set; } 

        [JsonProperty("managerid")]
        public int managerid { get; set; }

        [JsonProperty("advance_amount")]
        public int advance_amount { get; set; }

        [JsonProperty("tour_fromdate")]
        public string tour_fromdate { get; set; }

        [JsonProperty("tour_todate")]
        public string tour_todate { get; set; }

        [JsonProperty("places")]
        public string places { get; set; }

        [JsonProperty("purposes")]
        public string purposes { get; set; }

        [JsonProperty("days")]
        public int days { get; set; }

        [JsonProperty("age")]
        public int age { get; set; }
        [JsonProperty("projectname")]
        public string projectname { get; set; }
    }

    public class TourModel1
    {

        [JsonProperty("tourid")]
        public int tourid { get; set; }

        [JsonProperty("empid")]
        public string empid { get; set; }

        [JsonProperty("tour_fromdate")]
        public string tour_fromdate { get; set; }

        [JsonProperty("tour_todate")]
        public string tour_todate { get; set; }

        [JsonProperty("purposes")]
        public string purposes { get; set; }

        [JsonProperty("CreatedBy")]
        public string CreatedBy { get; set; }


    }

    public class TourSettlement
    {
        [JsonProperty("touradvance_id")]
        public int touradvance_id { get; set; }

        [JsonProperty("journey_amount")]
        public double journey_amount { get; set; }

        [JsonProperty("hotelstay_amount")]
        public double hotelstay_amount { get; set; }

        [JsonProperty("local_convenyance")]
        public double local_convenyance { get; set; }

        [JsonProperty("misc_expense")]
        public double misc_expense { get; set; }

        [JsonProperty("grand_total")]
        public double grand_total { get; set; }

        [JsonProperty("balances")]
        public double balances { get; set; }     


    }

    public class JourneyDetailsModel
    {
        [JsonProperty("touradvanceid")]
        public int touradvanceid { get; set; }
        [JsonProperty("source")]
        public string source { get; set; }
        [JsonProperty("departure")]
        public DateTime departure { get; set; }
        [JsonProperty("destination")]
        public string destination { get; set; }
        [JsonProperty("arrivaldatetime")]
        public DateTime arrivaldatetime { get; set; }
        [JsonProperty("modeoftravel")]
        public string modeoftravel { get; set; }
        [JsonProperty("fare")]
        public double? fare { get; set; }
        [JsonProperty("journeyda")]
        public double? journeyda { get; set; }
        [JsonProperty("totalamount")]
        public double? totalamount { get; set; }
        [JsonProperty("filepath")]
        public string filepath { get; set; }

    }
    public class JourneyDetailsModel1
    {
        [JsonProperty("touradvanceid")]
        public int touradvanceid { get; set; }
        [JsonProperty("source")]
        public string source { get; set; }
        [JsonProperty("departure")]
        public string departure { get; set; }
        [JsonProperty("destination")]
        public string destination { get; set; }
        [JsonProperty("arrivaldatetime")]
        public string arrivaldatetime { get; set; }
        [JsonProperty("modeoftravel")]
        public string modeoftravel { get; set; }
        [JsonProperty("fare")]
        public double? fare { get; set; }
        [JsonProperty("journeyda")]
        public double? journeyda { get; set; }
        [JsonProperty("totalamount")]
        public double? totalamount { get; set; }
        [JsonProperty("filepath")]
        public string filepath { get; set; }

    }
    public class HotelStayDetailsModel
    {
        [JsonProperty("touradvanceid")]
        public int touradvanceid { get; set; }
        [JsonProperty("place")]
        public string place { get; set; }
        [JsonProperty("fromdate")]
        public string  fromdate { get; set; }
        [JsonProperty("todate")]
        public string todate { get; set; }
      
        [JsonProperty("amount")]
        public double? amount { get; set; }
        [JsonProperty("da")]
        public double? da { get; set; }
   
        [JsonProperty("totalamount")]
        public double? totalamount { get; set; }
        [JsonProperty("filepath")]
        public string filepath { get; set; }

    }
    public class ConvenyanceDetailsModel
    {
        [JsonProperty("touradvanceid")]
        public int touradvanceid { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("fromplace")]
        public string fromplace { get; set; }
        [JsonProperty("toplace")]
        public string toplace { get; set; }

        [JsonProperty("modeoftransport")]
        public string modeoftransport { get; set; }

        [JsonProperty("totalamount")]
        public double? totalamount { get; set; }
        [JsonProperty("filepath")]
        public string filepath { get; set; }
    }

    public class MiscelianeousDetailsModel
    {
        [JsonProperty("touradvanceid")]
        public int touradvanceid { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("fromplace")]
        public string fromplace { get; set; }      

        [JsonProperty("totalamount")]
        public double? totalamount { get; set; }
        [JsonProperty("filepath")]
        public string filepath { get; set; }
    }
    public class TourAdvanceStatus
    {
        [JsonProperty("touradvanceid")]
        public int touradvanceid { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
    }
    public class TourAdvanceReport
    {
        [JsonProperty("fromdate")]
        public string fromdate { get; set; }
        [JsonProperty("todate")]
        public string todate { get; set; }
        [JsonProperty("employeeid")]
        public string employeeid { get; set; }

        [JsonProperty("departmentname")]
        public string departmentname { get; set; }
    }
   
    public class JourneyDetailsModelList
    {
        public List<JourneyDetailsModel1> journeys { get; set; }
    }
    public class HotelDetailsModelList
    {
        public List<HotelStayDetailsModel> hotels { get; set; }
    }
    public class ConvenyanceDetailsModelList
    {
        public List<ConvenyanceDetailsModel> convenyance { get; set; }
    }
    public class MiscelianeousDetailsModelList
    {
        public List<MiscelianeousDetailsModel> miscelianeous { get; set; }
    }

}
