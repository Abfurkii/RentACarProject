using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(m => m.Email).NotEmpty().WithMessage("Email alanı boş olamaz!");
            RuleFor(m => m.Email).EmailAddress();
            RuleFor(m => m.FirstName).NotEmpty().WithMessage("İsim alanı boş olamaz!");
            RuleFor(m => m.LastName).NotEmpty().WithMessage("Soyisim alanı boş olamaz!");
            RuleFor(m => m.FirstName).MinimumLength(3).WithMessage("İsim en az 3 karakter olmalıdır!");
            RuleFor(m => m.LastName).MinimumLength(2).WithMessage("Soyisim en az 2 karakterli olmalıdır!");
        }
    }
}
