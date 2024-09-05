using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Domain.Exceptions.Base;

namespace Supermarket.Domain.Exceptions
{
    public sealed class AttributeNotFoundException:NotFoundException
    {
        public AttributeNotFoundException(Guid  Id) : base($"không tồn tại {Id}")
        {

        }
    }
}
