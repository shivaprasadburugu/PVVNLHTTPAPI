using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Models
{
    public class NavBarResponse
    {
        public List<NavBarlist> ReportList { get; set; }
        public List<NavBarlist> TourList { get; set; }
        public List<NavBarlist> EmployeeList { get; set; }
        public List<NavBarlist> ConfigurationList { get; set; }
        public List<NavBarlist> AdminList { get; set; }
    }

    public class MobileNavBarResponse
    {
        public List<MobileNavBarlist> MobileReportList { get; set; }
       

    }

    public class NavBarlist
    {
        public int navbarid { get; set; }
        public int? roleid { get; set; }
        public string name { get; set; }
        public string area { get; set; }
        public int? parentid { get; set; }
        public string isparent { get; set; }
        public string haschild { get; set; }
        public string modulename { get; set; }
        public int navbarheaderid { get; set; }
        public int ischecked { get; set; }
        public List<subitems> subitems { get; set; }
        public List<NavBarlist> ChildReports { get; internal set; }
    }
    public class MobileNavBarlist
    {
        public int navbarid { get; set; }
        public int? roleid { get; set; }
        public string name { get; set; }
       
        public int ischecked { get; set; }
    }

    public class subitems
    {
       
        public int navbarid { get; set; }
        public int? roleid { get; set; }
        public string name { get; set; }
        public string area { get; set; }
        public int? parentid { get; set; }
        public string isparent { get; set; }
        public string haschild { get; set; }
        public string modulename { get; set; }
        public int navbarheaderid { get; set; }

        public List<subitems> Subitems { get; set; }

    }

    public class NavBarInsert
    {

        public string navbarname { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public string navstatus { get; set; }
        public int? parentid { get; set; }
        public string isparent { get; set; }
        public string haschild { get; set; }
        public string modulename { get; set; }
        public int navbarheaderid { get; set; }

    }
}
