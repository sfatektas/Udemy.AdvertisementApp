using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Adversitement.Common.Interfaces;

namespace Udemy.Adversitement.Common
{
   public class Response<T> : Response, IResponse<T> where T : class, new()
    {
        public T Data { get; set; }

        //Validasyon hatalarını döndürür ve UI kısmında gösteririz.
        public List<CustomValidationError> ValidationErrors { get; set; }

        public Response(ResponseType responseType) : base (responseType)
        {
        }

        public Response(string messages,ResponseType responseType) : base (messages,responseType)
        {
        }

        public Response( ResponseType responseType, T data, List<CustomValidationError> validationErrors ) :
            this(responseType)
        {
            Data = data;
            ValidationErrors = validationErrors;
        }

    }
}
