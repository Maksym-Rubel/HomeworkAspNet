using BusinessLogic.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
    public class CreateItemDtoVal : AbstractValidator<CreateItemDto>
    {
        public CreateItemDtoVal()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Minimum length must be more then 3");
        }
    }
}
