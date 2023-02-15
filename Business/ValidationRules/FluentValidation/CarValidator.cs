﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarId).GreaterThan(0);
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.Model).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan((short)0);
            RuleFor(c => c.Model).MinimumLength(3);
            RuleFor(c => c.DailyPrice).GreaterThan((short)0);
            RuleFor(c => c.Description).MinimumLength(3);
        }    


    }
}
