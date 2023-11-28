using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Models
{
    public class Marketer : BaseEntity
    {
        public long CoyId { get; set; }
        public long MemberId { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public string F5 { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ExpiryDate { get; set; }
        public string Plan { get; set; }
        public string CommBal { get; set; }
    } 
    public class MarketerFm
    {
        public long CoyId { get; set; }
        public long MemberId { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public string F5 { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ExpiryDate { get; set; }
        public string Plan { get; set; }
        public string CommBal { get; set; }
    }
    public class MarketerFmUpdate
    {
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public string F5 { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ExpiryDate { get; set; }
        public string Plan { get; set; }
     }
}
