using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(r => r.Description).NotEmpty().WithMessage("توضاحات وارد کنید ")
                .MinimumLength(10).WithMessage("should be more than 10") ;

            RuleFor(p => p.Price).GreaterThan(0).WithMessage("price in invalid");
        }
    }
}
