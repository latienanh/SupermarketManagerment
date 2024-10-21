using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.ModelResponses;
using Supermarket.Application.Services.Inventory.Commands.Sale;
using Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetAllInvoices;
using Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetChartSale;
using Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetSaleDateNow;

namespace Supermarket.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ApiController
    {
        [HttpGet("sql")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllInvoicesQuery();

            var result = await Sender.Send(query);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<InvoiceResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<InvoiceResponseDto>
                {
                    Message = "Không tìm thấy thông tin",
                    ListData = result
                });
            }
            return BadRequest(new ResponseFailure()
            {
                Message = "Lỗi",
            });
        }
        [HttpGet("sql/SaleDateNow")]
        public async Task<IActionResult> GetSaleDateNow()
        {
            var query = new GetSaleDateNowQuery();

            var result = await Sender.Send(query);
            if (result != null)
            {
                return Ok(new ResponseWithDataSuccess<SaleDateNowResponse>()
                {
                    Message = "Thành công",
                    Data = result
                });
            }
            return BadRequest(new ResponseFailure()
            {
                Message = "Lỗi",
            });
        }
        [HttpGet("sql/Chart")]
        public async Task<IActionResult> GetChart()
        {
            var query = new GetChartSaleQuery();

            var result = await Sender.Send(query);
            if (result != null)
            {
                return Ok(new ResponseWithDataSuccess<SaleDateNow1Response>()
                {
                    Message = "Thành công",
                    Data = result
                });
            }
            return BadRequest(new ResponseFailure()
            {
                Message = "Lỗi",
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(InvoiceRequest model,CancellationToken cancellationToken)
        {

            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var command = new SaleCommand(model, userId);
            var result = await Sender.Send(command,cancellationToken);
            if (result!=null)
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
