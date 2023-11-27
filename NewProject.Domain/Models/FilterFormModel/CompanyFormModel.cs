using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Models.FormModel
{
    public class CompanyFormModel: DefualtFormModel
    {
        public string PinnacleId { get; set; }
    } 
    public class DefualtFormModel
    {
        public string CoyId { get; set; }
    }
}
