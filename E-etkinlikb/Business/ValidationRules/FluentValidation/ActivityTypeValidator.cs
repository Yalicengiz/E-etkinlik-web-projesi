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
    public class ActivityTypeValidator:AbstractValidator<ActivityType>
    {
        //kurallar constructor içine yazılır!
        public ActivityTypeValidator()
        {
            RuleFor(p => p.ActivityTypeName).NotEmpty();
            RuleFor(p => p.ActivityTypeName).MinimumLength(2);
            RuleFor(p => p.ActivityTypeName).MaximumLength(20);
        }

    }
}
