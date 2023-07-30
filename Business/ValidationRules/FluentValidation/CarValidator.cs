using Entities.Concrete;
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

            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).NotEmpty();

            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100).When(p => p.ModelYear > 2020);

            RuleFor(c => c.ModelYear).Must(NewerThan80);
        }

        private bool NewerThan80(int arg)
        {
            if (arg < 1980) return false;
            return true;

        }
    }
}
