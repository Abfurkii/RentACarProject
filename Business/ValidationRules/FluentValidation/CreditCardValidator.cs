using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.CreditCardNumber).NotEmpty();
            RuleFor(x => x.Ccv).NotEmpty();
            RuleFor(x => x.Month).NotEmpty();
            RuleFor(x => x.Year).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.MemberId).NotEmpty();
            RuleFor(x => x.CreditCardNumber).Length(16);
            RuleFor(x => x.Ccv).Length(3);
            RuleFor(x => x.Year).GreaterThan(2021);
        }
    }
}
