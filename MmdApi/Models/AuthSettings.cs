using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Models
{
	public class AuthSettings
	{
		public string Site { get; set; }
		public string Audience { get; set; }
		public string ExpireTime { get; set; }
		public string Secret { get; set; }
		public string RefreshToken { get; set; }
		public string GrantType { get; set; }
		public string ClientId { get; set; }
        public double ExpireMinutes { get; internal set; }
    }
}
