using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Adversitement.Common.Interfaces
{
    //T değeri instance ı oluşturulabilecek bir sınıf olmalıdır.

    public interface IResponse<T> :IResponse where T : class ,new()
    {
        public T Data { get; set; }

        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}
