﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Exceptions.Base
{
    public abstract class NotFoundException:Exception
    {
        protected NotFoundException(string message) : base(message)
        {

        }
    }
}
