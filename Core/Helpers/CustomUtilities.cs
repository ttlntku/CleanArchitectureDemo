using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class CustomUtilities
    {
        public static DateTime CustomDatetimeConvert(DateTime dateTime, string format = "yyyy/MM/dd hh:mm:ss")
        {
            return Convert.ToDateTime(dateTime.ToString(format));
        }
    }
}
