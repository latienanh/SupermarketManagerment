﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Exceptions.Base
{
    public abstract class BadRequestException:Exception
    {
        protected BadRequestException(string message) : base(message) { }
    }
}
