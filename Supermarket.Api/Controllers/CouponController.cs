using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            if (result.IsNullOrEmpty())
                return BadRequest(new ResponseWithList<CouponResposeDto>
                {
                    Message = "Không có thông tin gì",
                    ListData = result
                }
                );
            return Ok(new ResponseWithList<CouponResposeDto>
            {
                Message = "Lấy thông tin thành công",
                ListData = result
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _couponServices.GetByIdAsync(id);
            if (result == null)
                return BadRequest(new ResponseWithData<CouponResposeDto>
                {
                    Message = "Không có thông tin gì",
                    Data = result
                }
                );
            return Ok(new ResponseWithData<CouponResposeDto>
            {
                Message = "Lấy thông tin thành công",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CouponRequestDto model)
        {
            var result = await _couponServices.CreateAsync(model);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Tạo không thành công"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _couponServices.DeleteAsync(id);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Xoá không thành công"
            });
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, CouponRequestDto model)
        {
            var result = await _couponServices.UpdateAsync(model, id);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Sửa không thành công"
            });
        }
    }
}

