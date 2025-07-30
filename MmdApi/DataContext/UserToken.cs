using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class UserToken
    {
        public int UserTokenId { get; set; }
        public string ClientId { get; set; }
        public string Value { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}
