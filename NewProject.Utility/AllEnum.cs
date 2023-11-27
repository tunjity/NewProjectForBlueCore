using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Utility
{
    public static class AllEnum
    {
        public enum ApprovalStatus : byte
        {
            Pending = 1,
            Approved,
            Rejected
        }
    }
}

