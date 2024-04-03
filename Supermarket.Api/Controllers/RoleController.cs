using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleServices;

        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roleServices.GetAllAsync();
            if (result.IsNullOrEmpty())
                return BadRequest(new ResponseWithList<RoleResponseDto>
                {
                    Message = "Không có thông tin gì",
                    ListData = result
                }
                );
            return Ok(new ResponseWithList<RoleResponseDto>
            {
                Message = "Lấy thông tin thành công",
                ListData = result
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roleServices.GetByIdAsync(id);
            if (result == null)
                return BadRequest(new ResponseWithData<RoleResponseDto>
                {
                    Message = "Không có thông tin gì",
                    Data = result
                }
                );
            return Ok(new ResponseWithData<RoleResponseDto>
            {
                Message = "Lấy thông tin thành công",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleRequestDto model)
        {
            var result = await _roleServices.CreateAsync(model);
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
            var result = await _roleServices.DeleteAsync(id);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Xoá không thành công"
            });
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, RoleRequestDto model)
        {
            var result = await _roleServices.UpdateAsync(model, id);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Sửa không thành công"
            });
        }
    }
}
