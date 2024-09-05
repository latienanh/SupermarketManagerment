using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Common
{
    public record BaseDTORequestUpdate()
    {
        public Guid Id { get; set; }
    }
}
