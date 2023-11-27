using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Models
{
    public class Product : BaseEntity
    {
        public long CoyId { get; set; }
        public string Description { get; set; }
        public string Pictures { get; set; }
        public long MarketerId { get; set; }
    }
    public class ProductFm
    {
        public long CoyId { get; set; }
        public string Description { get; set; }
        public string Pictures { get; set; }
        public long MarketerId { get; set; }
    }
}
