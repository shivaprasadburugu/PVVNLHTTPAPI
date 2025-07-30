using System;
using System.Collections.Generic;

namespace MdmApi.DataContext
{
    public partial class ConsumerTransactionLog
    {
        public string PaymentId { get; set; }
        public string TransactionId { get; set; }
        public string ConsumerId { get; set; }
        public string MeterNo { get; set; }
        public string TransactionType { get; set; }
        public string TransactionAmount { get; set; }
        public string MeterBalance { get; set; }
        public DateTime? UtilityTransactionDate { get; set; }
        public DateTime? TransactionReceivedDate { get; set; }
        public DateTime? TransactionCompleteDate { get; set; }
    }
}
