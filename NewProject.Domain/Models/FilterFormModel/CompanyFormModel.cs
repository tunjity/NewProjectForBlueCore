using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Models.FormModel
{
    public class CampaignFormModel : DefualtFormModel
    {
        public string Camapagnid { get; set; }
        public string ProductId { get; set; }
    }
    public class ClientFormModel : DefualtFormModel
    {
        public string ClientId { get; set; }
    }
    public class CommissionFormModel : DefualtFormModel
    {
        public string BenId { get; set; }
    }
    public class CompanyFormModel : DefualtFormModel
    {
        public string PinnacleId { get; set; }
    }
    public class DefualtFormModel
    {
        public string CoyId { get; set; }
    }
}
