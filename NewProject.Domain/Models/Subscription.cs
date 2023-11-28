using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Models
{
    public class Subscription : BaseEntity
    {
        public long CoyId { get; set; }
        public string TranxId { get; set; }
        public long MarketerId { get; set; }
        public string SubAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }  
    public class SubscriptionFm
    {
        public long CoyId { get; set; }
        public string TranxId { get; set; }
        public long MarketerId { get; set; }
        public string SubAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }  
    public class SubscriptionFmUpdate
    {
        public string TranxId { get; set; }
        public long MarketerId { get; set; }
        public string SubAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
