using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IImageServices _imageServices;

        public UserController(IUserServices userServices,IImageServices imageServices)
        {
            _userServices=userServices;
            _imageServices = imageServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userServices.GetAllAsync();
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<UserResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<UserResponseDto>
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
            var result = await _userServices.GetByIdAsync(id);
            if (result != null)
                return Ok(new ResponseWithDataSuccess<UserResponseDto>
                {
                    Message = "Tìm thấy thông tin",
                    Data = result
                });
            return BadRequest(new ResponseWithDataFailure<UserResponseDto>
            {
                Message = "Không tìm thấy thông tin",
                Data = result
            });
        }
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
        public async Task<IActionResult> Create([FromForm] UserRequestDto model)
        {

            if(model.Password!=model.ConfirmPassword)
                return BadRequest(new ResponseFailure()
            {
                Message = "Mật khẩu không trùng khớp"
            });

            var folderUsers = "images/users/";
                var userImagePath = await _imageServices.SaveImageAsync(folderUsers, model.Avatar);
                if (userImagePath == null)
                {
                    model.PathImage = "/images/default-image.jpg";
                }
                else if (!userImagePath.isSuccess)
                {
                    return BadRequest(new ResponseFailure()
                    {
                        Message = userImagePath.Message,
                    });
                }
                else
                {
                    model.PathImage = userImagePath.Data;
                }
            var result = await _userServices.CreateAsync(model);
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
            var result = await _userServices.DeleteAsync(id);
            if (result) return Ok(new ResponseSuccess()
                {
                    Message = "Xoá thành công",
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Xoá thất bại"
            });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromForm] UserUpdateRequestDto model)
        {
            var folderUsers = "images/users/";
                var userImagePath = await _imageServices.SaveImageAsync(folderUsers, model.Avatar);
                if (userImagePath == null)
                {
                    model.PathImage = null;
                }
                else if (!userImagePath.isSuccess)
                {
                    return BadRequest(new ResponseFailure()
                    {
                        Message = userImagePath.Message,
                    });
                }
                else
                {
                    model.PathImage = userImagePath.Data;
                }
            var result = await _userServices.UpdateAsync(model, id);
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
