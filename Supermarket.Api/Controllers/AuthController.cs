using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;


namespace Supermarket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authServices;
    private readonly IImageServices _imageServices;

    public AuthController(IAuthServices authServices, IImageServices imageServices)
    {
        _authServices = authServices;
        _imageServices = imageServices;
    }

    [HttpPost("SignUp")]
    public async Task<ActionResult> Signup([FromForm] SignUpRequestDto signUpRequestDto)
    {
        if (signUpRequestDto.Password != signUpRequestDto.ConfirmPassword)
            return BadRequest(new ResponseFailure()
            {
                Message = "Mật khẩu không trùng khớp"
            });
        var folderUsers = "images/users/";
        var userImagePath = await _imageServices.SaveImageAsync(folderUsers, signUpRequestDto.Avatar);
        if (userImagePath == null)
        {
            signUpRequestDto.PathImage = "/images/default-image.jpg";
        }
        else if (!userImagePath.isSuccess)
        {
            return BadRequest(new ResponseFailure()
            {
                Message = userImagePath.Message

            }
            );
        }
        else

        {
            signUpRequestDto.PathImage = userImagePath.Data;

        }

        var result = await _authServices.SignUp(signUpRequestDto);
        if (result.Succeeded)
            return Ok(new ResponseSuccess()
            {
                Message = "Tạo thành công!!!"
            });
        return BadRequest(new ResponseFailure()
        {
            Message = "Tạo không thành công!!!"
        });
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginBasicRequestDtos loginBasicRequestDtos)
    {
        var result = await _authServices.LoginAsync(loginBasicRequestDtos);
        if (result != null)
            return Ok(new ResponseWithDataSuccess<LoginResponseDtos>()
            {
                Data = result,
                Message = "Thành công"
            });
        return BadRequest(new ResponseFailure()
        {
            Message = "Thông tin tài khoản không chính xác"
        });

    }

    [HttpPost("Refresh")]
    public async Task<IActionResult> Refresh(LoginTokenRequestDtos loginTokenRequestDtos)
    {
        var result = await _authServices.RenewTokenAsync(loginTokenRequestDtos);
        if (result != null)
            return Ok(new ResponseWithDataSuccess<LoginResponseDtos>()
            {
                Data = result
            });
        return BadRequest(new ResponseFailure()
        {
            Message = "Thông tin token thất bại"
        });
    }
    [HttpPost("Logout")]
    [Authorize]
    public async Task<IActionResult> LogOut()
    {
        var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
        var result = await _authServices.LogOut(userId);
        if (result)
        {
            return Ok(new ResponseSuccess()
            {
                Message = "Đăng xuất thành công"
            });

        }
        return BadRequest(new ResponseFailure()
        {
            Message = "Đăng xuất thất bại"
        });
    }
}