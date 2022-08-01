
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos.GenderDtos;

namespace Udemy.AdvertisementApp.Bussines.ValidationRules.GenderRules
{
    public class GenderUpdateDtoValidator : AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateDtoValidator()
        {
            RuleFor(x => x.Defination).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
