using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Supermarket.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
       private ISender _sender;
       protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
