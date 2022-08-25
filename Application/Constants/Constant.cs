using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Application.Constants
{
    public static class Constant
    {
        public enum EnumPrint
        {
            [Description("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
            xlsx = 1,

            [Description("text/csv")]
            csv = 2
        }
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
}
