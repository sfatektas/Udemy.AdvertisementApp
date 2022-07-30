using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Advertisement.Entities;
using Udemy.AdvertisementApp.Dtos.ProvidedServicesDtos;

namespace Udemy.AdvertisementApp.Bussines.ValidationRules.ProvidedServiceRules
{
    public class ProvidedServiceUpdateDtoValidator : AbstractValidator<ProvidedServiceUpdateDto>
    {
        public ProvidedServiceUpdateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
