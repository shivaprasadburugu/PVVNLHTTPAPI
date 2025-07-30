using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class MasScopeAccessLevel
    {
        public MasScopeAccessLevel()
        {
            UserMaster = new HashSet<UserMaster>();
        }

        public int ScopeId { get; set; }
        public string ScopeName { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? InsertedDate { get; set; }

        public virtual ICollection<UserMaster> UserMaster { get; set; }
    }
}
