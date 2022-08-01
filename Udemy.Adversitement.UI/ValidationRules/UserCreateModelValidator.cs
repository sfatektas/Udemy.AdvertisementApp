using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Adversitement.UI.Models;

namespace Udemy.Adversitement.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Lastname).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("paswords not matches");
            RuleFor(x => new { x.Password, x.Username})
                .Must((x) => !x.Password.Contains(x.Username))
                .When(x => x.Username != null && x.Password != null);
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet alanını seçiniz.");
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Username).NotEmpty().MinimumLength(3);
            RuleFor(x => new { x.Username, x.Firstname }).Must(x => !x.Username.Contains(x.Firstname)).When(x=>x.Username!=null && x.Firstname!=null).WithMessage("Kullanıcı Firstname' i içeremez.");
        }
    }
}
