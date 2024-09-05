using Supermarket.Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Exceptions
{

    public sealed class ValidationException : BadRequestException
    {
        public ValidationException(Dictionary<string, string[]> errors)
            : base("Validation errors occurred") =>
            Errors = errors;

        public Dictionary<string, string[]> Errors { get; }
    }

}
