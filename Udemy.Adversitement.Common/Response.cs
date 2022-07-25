using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Adversitement.Common.Interfaces;

namespace Udemy.Adversitement.Common
{
    //Response sınıfının birde interface i oluşturulacaktır.

    public class Response :IResponse
    {
        public string Message { get; set; }

        public ResponseType ResponseType { get; set; }

        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public Response(string message, ResponseType responseType)
        {
            Message = message;
            ResponseType = responseType;
        }
    }
    public enum ResponseType
    {
        Success,
        NotFound,
        ValidationError
    }
}
