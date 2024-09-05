using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Supermarket.Application.Services.Product.Commands.DeleteProduct
{
    public class DeleteAttributeCommandValidator : AbstractValidator<DeleteAttributeRequest>
    {
        public DeleteAttributeCommandValidator()
        {
            RuleFor(x=>x.Id ).NotEmpty();
        }
    }
}
