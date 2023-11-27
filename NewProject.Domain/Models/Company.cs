using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewProject.Domain.Models
{
    public class Company:BaseEntity
    {
        public string CoyName { get; set; }
        public string CoyAddress { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
        public string Country { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string Descrpt { get; set; }
        public string Industry { get; set; }
        public string PinnacleId { get; set; }
    }
    public class CompanyFm
    { 
        public string CoyName { get; set; }
        public string CoyAddress { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
        public string Country { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Descrpt { get; set; }
        public string Industry { get; set; }
        public string PinnacleId { get; set; }
    }
}
