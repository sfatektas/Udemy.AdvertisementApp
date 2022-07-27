using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Adversitement.Common;

namespace Udemy.AdvertisementApp.Bussines.ValidationExtensions
{
    public static class ValidationExtension
    {
        public static List<CustomValidationError> ConvertToErrorList(this ValidationResult result)
        {
            List<CustomValidationError> list = new();
            foreach (var error in result.Errors)
            {
                list.Add(new CustomValidationError()
                {
                    ErrorMesages = error.ErrorMessage,
                    PropertyName = error.PropertyName
                });
            }
            return list;
        }
    }
}
