using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PriceTypeValidator:AbstractValidator<PriceType>
    {
        public PriceTypeValidator()
        {
            RuleFor(p => p.PriceTypeName).NotEmpty();
            RuleFor(p => p.PriceTypeName).MinimumLength(2);
            RuleFor(p => p.PriceTypeName).MaximumLength(20);
        }
    }
}
