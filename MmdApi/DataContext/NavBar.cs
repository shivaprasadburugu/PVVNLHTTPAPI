using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class NavBar
    {
        public int NavBarId { get; set; }
        public int? RoleId { get; set; }
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Area { get; set; }
        public string ImageClass { get; set; }
        public string Status { get; set; }
        public int? ParentId { get; set; }
        public string IsParent { get; set; }
        public string Haschild { get; set; }
        public string ModuleName { get; set; }

        public virtual MasRole Role { get; set; }
    }
}
