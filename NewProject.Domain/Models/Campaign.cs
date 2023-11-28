using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Models
{
    public class Campaign : BaseEntity
    {
        public long CoyId { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long CampaignId { get; set; }
        public long ProductId { get; set; }
        public string CampaignType { get; set; }
        public string Content { get; set; }
        public string Position { get; set; }
        public string DaysAfter { get; set; }
    }
    public class CampaignFm
    {
        public long CoyId { get; set; }
        public long ProductId { get; set; }
        public string CampaignType { get; set; }
        public string Content { get; set; }
        public string Position { get; set; }
        public string DaysAfter { get; set; }
    }

    public class CampaignUpdateFm
    {
        public long ProductId { get; set; }
        public string CampaignType { get; set; }
        public string Content { get; set; }
        public string Position { get; set; }
        public string DaysAfter { get; set; }
    }
}
