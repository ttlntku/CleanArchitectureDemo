using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Constants
{
    public static class ConstantValidatorMessage
    {
        public static readonly Func<string, string> MESSAGE_IS_EMPTY = name => $"{name} is empty";

        public static readonly Func<string, string> MESSAGE_MAX_LENGTH_50 = name => $"{name} must be less than 50 characters";

        public static readonly Func<string, string> MESSAGE_MAX_LENGTH_10 = name => $"{name} must be less than 10 characters";
    }
}
