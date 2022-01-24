using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ActivityValidator: AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(p => p.ActivityName).NotEmpty();
            RuleFor(p => p.ActivityName).MinimumLength(2);
            RuleFor(p => p.ActivityName).MaximumLength(20);
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Description).Length(0, 1000);
            RuleFor(p => p.ActivityTypeId).NotEmpty();
            RuleFor(p => p.PriceTypeId).NotEmpty();
        }
    }
}
