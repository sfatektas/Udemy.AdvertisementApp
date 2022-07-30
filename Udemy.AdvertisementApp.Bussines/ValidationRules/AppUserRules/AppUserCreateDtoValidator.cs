using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Dtos.AppUserDtos;

namespace Udemy.AdvertisementApp.Bussines.ValidationRules.AppUserRules
{
    public class AppUserCreateDtoValidator : AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username alanını doldurunuz.");
            RuleFor(x => x.Firstname).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Lastname).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50);
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
        }
    }
}
