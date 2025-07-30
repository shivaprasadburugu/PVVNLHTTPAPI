using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class MasRole
    {
        public MasRole()
        {
            NavBar = new HashSet<NavBar>();
            UserMaster = new HashSet<UserMaster>();
        }

        public int RoleId { get; set; }
        public string RoleType { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }

        public virtual ICollection<NavBar> NavBar { get; set; }
        public virtual ICollection<UserMaster> UserMaster { get; set; }
    }
}
