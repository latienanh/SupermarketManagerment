using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;
namespace Supermarket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

[Authorize]
public class AttributeController : ControllerBase
{
    private readonly IAttributeServices _attributeServices;
    private int userId = 1;

    public AttributeController(IAttributeServices attributeServices)
    {
        _attributeServices = attributeServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _attributeServices.GetAllAsync();
        if (result.Any())
            return Ok(new ResponseWithList<AttributeResponseDto>
            {
                Message = "Tìm thấy thành công",
                ListData = result
            });
        return BadRequest(new ResponseWithList<AttributeResponseDto>
        {
            Message = "Không tìm thấy thông tin",
            ListData = result
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _attributeServices.GetByIdAsync(id);
        if (result != null)
            return Ok(new ResponseWithData<AttributeResponseDto>
            {
                Data = result
            });
        return BadRequest(new ResponseWithData<AttributeResponseDto>
        {
            Message = "Không tìm thấy thông tin",
            Data = result
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(AttributeRequestDto attributeDto)
    {
        int userId = Convert.ToInt32(HttpContext.User.FindFirstValue("userId"));
        
        var result = await _attributeServices.CreateAsync(attributeDto);
        if (result)
            return Ok(new ResponseBase());
        return BadRequest(new ResponseBase()
        {
            Message = "Tạo không thành công!!!"
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update(AttributeRequestDto attributeDto, int id)
    {
        var result = await _attributeServices.UpdateAsync(attributeDto, id);
        if (result)
        return Ok(new ResponseBase());
        return BadRequest(new ResponseBase()
        {
            Message = "Sửa không thành công"
        });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _attributeServices.DeleteAsync(id);
        if(result)
        return Ok(new ResponseBase());
        return BadRequest(new ResponseBase()
        {
            Message = "Xoá không thành công"
        });
    }
}