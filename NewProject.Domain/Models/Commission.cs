using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Models
{
    public class Commission : BaseEntity
    {
        public long CoyId { get; set; }
        public string TranxBy { get; set; }
        public long BenId { get; set; }
        public string TranxAmount { get; set; }
        public string Description { get; set; }
    } public class CommissionFm
    {
        public long CoyId { get; set; }
        public string TranxBy { get; set; }
        public long BenId { get; set; }
        public string TranxAmount { get; set; }
        public string Description { get; set; }
    }

     public class CommissionFmUpdate
    {
        public string TranxBy { get; set; }
        public long BenId { get; set; }
        public string TranxAmount { get; set; }
        public string Description { get; set; }
    }
}
