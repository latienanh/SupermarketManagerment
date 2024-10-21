using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.ModelResponses;
using Supermarket.Application.Services.Inventory.Commands.ImportGoods;
using Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetAllStockIn;

namespace Supermarket.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImportGoodsController : ApiController
    {

        [HttpGet("sql")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllStockInQuery();

            var result = await Sender.Send(query);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<StockInResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<StockInResponseDto>
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
        [HttpPost]
        public async Task<IActionResult> Create(ImportGoodsRequest model,CancellationToken cancellationToken)
        {

            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var command = new ImportGoodsCommand(model,userId);
            
            var result = await Sender.Send(command,cancellationToken);
            if (result != null)
                return Ok(new ResponseSuccess()
                {
                    Message = "Nhập thành công!!!"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Nhập hàng không thành công!!!"
            });
        }
    }
}
