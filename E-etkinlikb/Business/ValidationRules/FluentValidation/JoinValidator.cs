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
    public class JoinValidator:AbstractValidator<Join>
    {
        public JoinValidator()
        {
            RuleFor(p => p.ActivityId).NotEmpty();
            RuleFor(p => p.CustomerId).NotEmpty();
            RuleFor(p => p.ReturnDate).GreaterThan(1900);
        }
    }
}
