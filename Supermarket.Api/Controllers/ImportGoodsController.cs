using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.ModelResponses;
using System.Security.Claims;
using Supermarket.Application.IServices;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImportGoodsController : ControllerBase
    {
        private readonly IImportGoodsServices _importGoodsServices;

        public ImportGoodsController(IImportGoodsServices importGoodsServices)
        {
            _importGoodsServices = importGoodsServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _importGoodsServices.GetAllStockInAsync();
            //if (result != null)
            //{
            //    if (result.Any())
            //        return Ok(new ResponseWithListSuccess<ProductResponseDto>
            //        {
            //            Message = "Tìm thấy thành công",
            //            ListData = result
            //        });
            //    return Ok(new ResponseWithListSuccess<ProductResponseDto>
            //    {
            //        Message = "Không tìm thấy thông tin",
            //        ListData = result
            //    });
            //}

            return BadRequest(new ResponseFailure()
            {
                Message = "Lỗi",
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create( ImportGoodsRequest model)
        {

            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var result = await _importGoodsServices.CreateStockInAsync(model, userId);
            if (result)
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
