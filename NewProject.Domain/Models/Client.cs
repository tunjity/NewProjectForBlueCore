using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Models
{
    public class Client : BaseEntity
    {
        public long CoyId { get; set; }
        public string ClientName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
    }
    public class ClientFm
    {
        public long CoyId { get; set; }
        public string ClientName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
    }

     public class ClientFmUpdate
    {
        public string ClientName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
    }
}
