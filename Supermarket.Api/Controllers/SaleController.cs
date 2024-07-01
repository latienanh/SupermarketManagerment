using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.ModelResponses;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Supermarket.Application.IServices;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.Services;

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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _salesService.GetAllStockInAsync();
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
        [HttpGet("SaleDateNow")]
        public async Task<IActionResult> GetSaleDateNow()
        {
            var result = await _salesService.GetSaleDateNow();
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
        [HttpGet("Chart")]
        public async Task<IActionResult> GetChart()
        {
            var result = await _salesService.GetChart();
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
