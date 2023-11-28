using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Utility
{
    public static class Helper
    {
        public static string GetBase64StringForImage(IFormFile file)
        {
            string val = null;

            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    val = Convert.ToBase64String(fileBytes);
                }
            }
            return val;
        }
    }
}
