using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Product.Commands.DeleteProduct
{
    public sealed record DeleteAttributeCommand(Guid Id,Guid UserId) : ICommand<Guid>
    {
    }
}
