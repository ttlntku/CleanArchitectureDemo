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

        public static T IsNullOrSecondValue<T>(T firstValue, T secondValue)
        {
            if (!EqualityComparer<T>.Default.Equals(firstValue, default(T)))
            {
                return firstValue;
            }
            return secondValue;
        }
    }
}
