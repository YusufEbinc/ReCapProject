using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public  class CarValidaiton: AbstractValidator<Car>
    {
        public CarValidaiton()
        {
            RuleFor(C => C.CarName.Length > 2);
            RuleFor(C => C.DailyPrice > 0);
        }


    }
}
