using System;

namespace MdmApi.Web.Models
{
    public class ServiceConfiguration
    {
        public JwtSettings JwtSettings { get; set; }
        public string AttendanceConnection { get; set; }         
    }
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
   
}
