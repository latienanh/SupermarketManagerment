using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;

namespace Supermarket.Application.Services.Product.Commands.CreateProduct
{
    public class CreateAttributeCommandValidator : AbstractValidator<CreateAttributeRequest>
    {
        public CreateAttributeCommandValidator()
        {
            RuleFor(x=>x.BarCode).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Describe).NotEmpty();
        }
    }
}
