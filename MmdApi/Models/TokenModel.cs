using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdmApi.Models
{
	public class TokenModel
	{
		public int Id { get; set; }
		public string ClinetId { get; set; }
		public string Value { get; set; }
		public DateTime CreatedDate { get; set; }
		public string UserId { get; set; }
		public DateTime LastModifiedDate { get; set; }
		public DateTime ExpiryTime { get; set; }

	}
	public class TokenRequestModel { 
		public string GrantType { get; set; }
		public string ClientId { get; set; }
		public string UserName { get; set; }
		public string RefreshToken { get; set; }
	}

	public class TokenResponseModel
	{
		public string token { get; set; }
		public DateTime expiration { get; set; }
		public string refresh_token { get; set; }
		public string roles { get; set; }
		public string username { get; set; }
	}
}
