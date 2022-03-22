using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee.API.Helpers
{
    public class CustomApiResponse
    {
        public string SentAt { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public object Result { get; set; }
        [JsonConstructor]
        public CustomApiResponse(string message, object result, int status = StatusCodes.Status200OK)
        {
            this.SentAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now);
            this.Message = message;
            this.Status = status;
            this.Result = result;
        }
    }
}
