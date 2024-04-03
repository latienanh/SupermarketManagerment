﻿using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.Auth;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.IServices;


namespace Supermarket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authServices;

    public AuthController(IAuthServices authServices)
    {
        _authServices = authServices;
    }

    [HttpPost("SignUp")]
    public async Task<ActionResult> Signup(UserRequestDto userRequestDtos)
    {
        var result = await _authServices.SignUp(userRequestDtos);
        if (result.Succeeded) 
            return Ok(result);

        return Unauthorized(result);
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginBasicRequestDtos loginBasicRequestDtos)
    {
        var result = await _authServices.LoginAsync(loginBasicRequestDtos);
        if (string.IsNullOrEmpty(result.AccessToken)) return Unauthorized();
        ;
        return Ok(result);
    }

    [HttpPost("Refresh")]
    public async Task<IActionResult> Refresh(LoginTokenRequestDtos loginTokenRequestDtos)
    {
        var result = await _authServices.RenewTokenAsync(loginTokenRequestDtos);
        if (result != null) return Ok(result);

        return BadRequest();
    }
}