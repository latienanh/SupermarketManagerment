using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.ModelResponses;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Supermarket.Application.IServices;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SaleController(ISalesService salesService)
        {
            _salesService = salesService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(InvoiceRequestDto model)
        {

            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var result = await _salesService.CreateInvoiceAsync(model, userId);
            if (result)
                return Ok(new ResponseSuccess()
                {
                    Message = "Bán thành công!!!"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Bán hàng không thành công!!!"
            });
        }
    }
}
