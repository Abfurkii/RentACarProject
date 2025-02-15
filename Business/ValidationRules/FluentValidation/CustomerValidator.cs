﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cus => cus.UserId).NotEmpty();
            RuleFor(cus => cus.CompanyName).NotEmpty();
        }
    }
}
