using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CouponController : ControllerBase
    {
        private readonly ICouponServices _couponServices;
        public CouponController(ICouponServices couponServices)
        {
            _couponServices = couponServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _couponServices.GetAllAsync();
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<CouponResposeDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<CouponResposeDto>
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _couponServices.GetByIdAsync(id);
            if (result != null)
                return Ok(new ResponseWithDataSuccess<CouponResposeDto>
                {
                    Message = "Tìm thấy thông tin",
                    Data = result
                });
            return BadRequest(new ResponseWithDataFailure<CouponResposeDto>
            {
                Message = "Không tìm thấy thông tin",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CouponRequestDto model)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var result = await _couponServices.CreateAsync(model, userId);
            if (result)
                return Ok(new ResponseSuccess()
                {
                    Message = "Tạo thành công!!!"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Tạo không thành công!!!"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var result = await _couponServices.DeleteAsync(id, userId);
            if (result)
                return Ok(new ResponseSuccess()
                {
                    Message = "Xoá thành công",
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Xoá thất bại"
            });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CouponRequestDto model)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var result = await _couponServices.UpdateAsync(model, id, userId);
            if (result)
                return Ok(new ResponseSuccess()
                {
                    Message = "Sửa thành công!!!"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Sửa thất bại!!!"
            });
        }
    }
}

