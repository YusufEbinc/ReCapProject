using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public  class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(C => C.CarName).MinimumLength(2);
            RuleFor(C => C.DailyPrice).NotEmpty();
            RuleFor(C => C.DailyPrice).GreaterThan(0);
        }


    }
}
