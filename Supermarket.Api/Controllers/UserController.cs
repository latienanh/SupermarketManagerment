using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices=userServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userServices.GetAllAsync();
            if (result.IsNullOrEmpty())
                return BadRequest(new ResponseWithList<UserResponseDto>
                    {
                        Message = "Không có thông tin gì",
                        ListData = result
                    }
                );
            return Ok(new ResponseWithList<UserResponseDto>
            {
                Message = "Lấy thông tin thành công",
                ListData = result
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _userServices.GetByIdAsync(id);
            if (result == null)
                return BadRequest(new ResponseWithData<UserResponseDto>
                    {
                        Message = "Không có thông tin gì",
                        Data = result
                    }
                );
            return Ok(new ResponseWithData<UserResponseDto>
            {
                Message = "Lấy thông tin thành công",
                Data = result
            });
        }
        [Authorize]
        [HttpGet]
        [Route("/current")]
        public async Task<IActionResult> GetLoggedInUserId()
        {
            int id = Convert.ToInt32(HttpContext.User.FindFirstValue("userId"));
            return Ok(new
            {
                userId = id
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequestDto model)
        {
            if(model.Password!=model.ConfirmPassword)
                return BadRequest(new ResponseBase
            {
                Message = "Mật khẩu không trùng khớp"
            });
            var result = await _userServices.CreateAsync(model);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Tạo không thành công"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userServices.DeleteAsync(id);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Xoá không thành công"
            });
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, UserRequestDto model)
        {
            var result = await _userServices.UpdateAsync(model, id);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Sửa không thành công"
            });
        }
    }
}
