using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.Abstractions.IImageservices;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.ModelResponses;
using Supermarket.Application.Services.User.Commands.CreateUser;
using Supermarket.Application.Services.User.Commands.DeleteUser;
using Supermarket.Application.Services.User.Commands.UpdateUser;
using Supermarket.Application.Services.User.Queries.SQLServerQueries.GetAllUsers;
using Supermarket.Application.Services.User.Queries.SQLServerQueries.GetPagingUsers;
using Supermarket.Application.Services.User.Queries.SQLServerQueries.GetTotalPagingUsers;
using Supermarket.Application.Services.User.Queries.SQLServerQueries.GetUserById;

namespace Supermarket.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ApiController
    {

        private readonly IImageServices _imageServices;

        public UserController(IImageServices imageServices)
        {

            _imageServices = imageServices;
        }

        [HttpGet("sql")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var result = await Sender.Send(query);
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
        [HttpGet("sql/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await Sender.Send(query);
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
        [HttpGet("sql/GetPaging")]
        public async Task<IActionResult> GetPaging(int index, int size)
        {
            var query = new GetPagingUsersQuery(index, size);
            var result = await Sender.Send(query);
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
        [HttpGet("sql/TotalPaging")]
        public async Task<IActionResult> GetTotalPaging(int size)
        {
            var query = new GetTotalPagingUsersQuery( size);
            var result = await Sender.Send(query);
            if (result != null)
            {
                if (result > 0)
                    return Ok(new ResponseWithDataSuccess<int>()
                    {
                        Message = "Thành công",
                        Data = result
                    });
                return Ok(new ResponseWithDataFailure<int>()
                {
                    Message = "Thất bại",
                    Data = result
                });
            }
            return BadRequest(new ResponseFailure()
            {
                Message = "Lỗi",
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
        public async Task<IActionResult> Create([FromForm] CreateUserRequest model)
        {
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

            var command = new CreateUserCommand(model);

            var result = await Sender.Send(command);
            if (result != null)
                return Ok(new ResponseSuccess()
                {
                    Message = "Tạo thành công!!!"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Tạo không thành công!!!"
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserRequest deleteUserRequest)
        {
            var command = new DeleteUserCommand(deleteUserRequest);

            var result = await Sender.Send(command);
            if (result != null) return Ok(new ResponseSuccess()
            {
                Message = "Xoá thành công",
            });
            return BadRequest(new ResponseFailure()
            {
                Message = "Xoá thất bại"
            });
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateUserRequest model)
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
            var command = new UpdateUserCommand(model);

            var result = await Sender.Send(command);
            if (result != null)
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
