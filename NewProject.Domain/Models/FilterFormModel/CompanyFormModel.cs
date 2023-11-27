using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Models.FormModel
{
    public class CampaignFormModel : DefualtFormModel
    {
        public string? Camapagnid { get; set; }
        public string? ProductId { get; set; }
    }
    public class ClientFormModel : DefualtFormModel
    {
        public string? ClientId { get; set; }
    }
    public class SubscriptionFormModel : DefualtFormModel
    {
        public string? marketerId { get; set; }
        public string? tranxid { get; set; }
    }
    public class ProductFormModel : DefualtFormModel
    {
        public string? ProductId { get; set; }
        public string? MarketerId { get; set; }
    }
    public class MarketerFormModel : DefualtFormModel
    {
        public string? MemberId { get; set; }
    }
    public class LogFormModel : DefualtFormModel
    {
        public string? ClientId { get; set; }
        public string? marketerId { get; set; }
        public string? produtid { get; set; }
    }
    public class CommissionFormModel : DefualtFormModel
    {
        public string? BenId { get; set; }
    }
    public class CompanyFormModel : DefualtFormModel
    {
        public string? PinnacleId { get; set; }
    }
    public class DefualtFormModel
    {
        [Required]
        public string CoyId { get; set; }
    }
}
