using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Domain.Model.Output
{
    public enum ResponseType
    {
        Success,
        Failure,
        Warning
    }
    public class Response
    {
        public Response(string message, ResponseType type, object data)
        {
            Message = message;
            Type = type;
            Data = data;
        }

        public string Message { get; set; }
        public ResponseType Type { get; set; }
        public object Data { get; set; }

        public static Response Success(string message, object data = null) => new Response(message, ResponseType.Success, data);
        public static Response Failure(string message, object data = null) => new Response(message, ResponseType.Failure, data);
        public static Response Warning(string message, object data = null) => new Response(message, ResponseType.Warning, data);
    }
}
