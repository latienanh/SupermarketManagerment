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
    public class MemberShipTypeController : ControllerBase
    {
        private readonly IMemberShipTypeServices _memberShipTypeServices;
        public MemberShipTypeController(IMemberShipTypeServices memberShipTypeServices)
        {
            _memberShipTypeServices = memberShipTypeServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _memberShipTypeServices.GetAllAsync();
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<MemberShipTypeResposeDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<MemberShipTypeResposeDto>
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
            var result = await _memberShipTypeServices.GetByIdAsync(id);
            if (result != null)
                return Ok(new ResponseWithDataSuccess<MemberShipTypeResposeDto>
                {
                    Message = "Tìm thấy thông tin",
                    Data = result
                });
            return BadRequest(new ResponseWithDataFailure<MemberShipTypeResposeDto>
            {
                Message = "Không tìm thấy thông tin",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MemberShipTypeRequestDto entity)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var result = await _memberShipTypeServices.CreateAsync(entity, userId);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(MemberShipTypeRequestDto entity, Guid id)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var result = await _memberShipTypeServices.UpdateAsync(entity, id, userId);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var result = await _memberShipTypeServices.DeleteAsync(id, userId);
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
    }
}
