using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidation : AbstractValidator<Rental>
    {
        public RentalValidation()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Id).GreaterThan(2);
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CarId).GreaterThan(2);
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.CustomerId).GreaterThan(2);
            RuleFor(r => r.RentDate).Empty().When(r => r.ReturnDate == null);
        }
    }
}
