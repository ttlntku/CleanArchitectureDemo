using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Helpers
{
    public static class CustomUtilities
    {
        public static string CustomDatetimeConvert(DateTime dateTime, string format = "yyyy/MM/dd hh:mm:ss")
        {
            return dateTime.ToString(format);
        }
    }
}
