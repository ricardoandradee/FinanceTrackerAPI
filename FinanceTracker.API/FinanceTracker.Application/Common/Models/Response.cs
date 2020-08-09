using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Common.Models
{
    public static class Response
    {
        public static Response<T> Fail<T>(string message, T data = default) =>
            new Response<T>(data, message, false);

        public static Response<T> Success<T>(T data = default) =>
            new Response<T>(data, string.Empty, true);
    }
    public class Response<T>
    {
        public Response(T data, string message, bool ok)
        {
            Data = data;
            Message = message;
            Ok = ok;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public bool Ok { get; set; }
    }


}
