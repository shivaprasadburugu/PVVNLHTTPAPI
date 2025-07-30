using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class UserMaster
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string EmployeeId { get; set; }
        public string UserLoginId { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string CellPhone { get; set; }
        public string OfficeLandline { get; set; }
        public string OfficeAddress { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public int RoleId { get; set; }
        public string ScopeAccessLevel { get; set; }
        public int ScopeAccessValueId { get; set; }
        public string Sms { get; set; }
        public string Mail { get; set; }
        public int? UserStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual MasRole Role { get; set; }
        public virtual MasScopeAccessLevel ScopeAccessValue { get; set; }
    }
}
