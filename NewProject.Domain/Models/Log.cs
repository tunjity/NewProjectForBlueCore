using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Models
{
    public class Log : BaseEntity
    {
        public long CoyId { get; set; }
        public long ClientId { get; set; }
        public long MarketerId { get; set; }
        public long ProducId { get; set; }
        public string LastCampId { get; set; }
        public string LastResponseId { get; set; }
        public DateTime LastCampDate { get; set; }
    }
    public class LogFm
    {
        public long CoyId { get; set; }
        public long ClientId { get; set; }
        public long MarketerId { get; set; }
        public long ProducId { get; set; }
        public string LastCampId { get; set; }
        public string LastResponseId { get; set; }
        public DateTime LastCampDate { get; set; }
    }
}   

