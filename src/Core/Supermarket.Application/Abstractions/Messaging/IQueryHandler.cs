using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Supermarket.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery,TResponse>:IRequestHandler<TQuery,TResponse> where TQuery: IQuery<TResponse>
    {
    }
}
