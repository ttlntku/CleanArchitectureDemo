using AutoWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.ApiResponse
{
    public class MapResponseObject
    {
        [AutoWrapperPropertyMap(Prop.Result)]
        public object Data { get; set; }

        [AutoWrapperPropertyMap(Prop.ResponseException)]
        public object Error { get; set; }

        [AutoWrapperPropertyMap(Prop.ResponseException_ExceptionMessage)]
        public string Message { get; set; }

        [AutoWrapperPropertyMap(Prop.ResponseException_Details)]
        public string StackTrace { get; set; }
    }
    public class Error
    {
        public string Message { get; set; }

        public string Code { get; set; }
        public InnerError InnerError { get; set; }

        public Error(string message, string code, InnerError inner)
        {
            this.Message = message;
            this.Code = code;
            this.InnerError = inner;
        }

    }

    public class InnerError
    {
        public string RequestId { get; set; }
        public string Date { get; set; }

        public InnerError(string reqId, string reqDate)
        {
            this.RequestId = reqId;
            this.Date = reqDate;
        }
    }
}
