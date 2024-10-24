﻿using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.Abstractions.IImageservices;
using Supermarket.Application.Abstractions.ISendMailServices;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.ModelResponses;
using Supermarket.Application.Services.Authentication.Commands.Login;
using Supermarket.Application.Services.Authentication.Commands.Logout;
using Supermarket.Application.Services.Authentication.Commands.Register;
using Supermarket.Application.Services.Authentication.Commands.RenewToken;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ApiController
{
    private readonly IImageServices _imageServices;
    private readonly ISendMailServices _sendMailServices;
    private readonly UserManager<AppUser> _userManager;


    public AuthController(  IImageServices imageServices,ISendMailServices sendMailServices,UserManager<AppUser> userManager)
    {
        _imageServices = imageServices;
        _sendMailServices = sendMailServices;
        _userManager = userManager;
    }

    [HttpPost("SignUp")]
    public async Task<ActionResult> Signup([FromForm] RegisterRequest registerRequest,CancellationToken cancellationToken)
    {
        var folderUsers = "images/users/";
        var userImagePath = await _imageServices.SaveImageAsync(folderUsers, registerRequest.Avatar);
        if (userImagePath == null)
        {
            registerRequest.PathImage = "/images/default-image.jpg";
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
            registerRequest.PathImage = userImagePath.Data;

        }
        var command =  new RegisterCommand(registerRequest);
        var result = await Sender.Send(command,cancellationToken);
        if (result!=null)
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
    public async Task<ActionResult> Login(LoginRequest loginRequest,CancellationToken cancellationToken)
    {
        var command = new LoginCommand(loginRequest);
        var result = await Sender.Send(command, cancellationToken);
        if (result != null)
            return Ok(new ResponseWithDataSuccess<LoginResponse>()
            {
                Data = result,
                Message = "Thành công"
            });
        return BadRequest(new ResponseFailure()
        {
            Message = "Thông tin tài khoản không chính xác"
        });

    }
    [HttpPost("ForgotPassword")]
    public async  Task<ActionResult> ForgotPassword(ForgotPasswordRequestDto model)
    {
        
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
            return BadRequest(new ResponseFailure()
        {
            Message = "Email không có trong hệ thống"
        });

        // Tạo mã token để reset password
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result =  _sendMailServices.SendMail(model.Email,"Quen mat khau",token,"");
        if (result != null)
            return Ok(new ResponseWithDataSuccess<bool>()
            {
                Data = result,
                Message = "Thành công"
            });
        return BadRequest(new ResponseFailure()
        {
            Message = "Thông tin tài khoản không chính xác"
        });

    }
    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword(ResetPasswordRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResponseFailure()
        {
            Message = "Không đúng kiểu"
        });
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return BadRequest(new ResponseFailure()
            {
                Message = "Không có user trong hệ thống"
            });
        }

        // Đặt lại mật khẩu mới
        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        if (!result.Succeeded)
        {
            return BadRequest(new ResponseFailure()
            {
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            });
        }
        return Ok(new ResponseSuccess()
        {
            Message = "Reset mật khẩu Thành công"
        });
    }
    [HttpPost("Refresh")]
    public async Task<IActionResult> Refresh(RenewTokenRequest renewTokenRequest,CancellationToken cancellationToken)
    {
        var command = new RenewTokenCommand(renewTokenRequest);
        var result = await Sender.Send(command, cancellationToken);
        if (result != null)
            return Ok(new ResponseWithDataSuccess<LoginResponse>()
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
    public async Task<IActionResult> LogOut(CancellationToken cancellationToken)
    {
        var logoutRequest = new LogoutRequest(Guid.Parse(HttpContext.User.FindFirstValue("userId")));
       
        //var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));

        var command = new LogoutCommand(logoutRequest);
        var result = await Sender.Send(command, cancellationToken);
        if (result!=null)
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