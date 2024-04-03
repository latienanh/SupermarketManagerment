using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttributeValueController : ControllerBase
{
    private readonly IAttributeValueServices _attributeValueServices;

    public AttributeValueController(IAttributeValueServices attributeValueServices)
    {
        _attributeValueServices = attributeValueServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _attributeValueServices.GetAllAsync();
        if (result.IsNullOrEmpty())
            return BadRequest(new ResponseWithList<AttributeValueResponseDto>
                {
                    Message = "Không có thông tin gì",
                    ListData = result
                }
            );
        return Ok(new ResponseWithList<AttributeValueResponseDto>
        {
            Message = "Lấy thông tin thành công",
            ListData = result
        });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _attributeValueServices.GetByIdAsync(id);
        if (result == null)
            return BadRequest(new ResponseWithData<AttributeValueResponseDto>
                {
                    Message = "Không có thông tin gì",
                    Data = result
                }
            );
        return Ok(new ResponseWithData<AttributeValueResponseDto>
        {
            Message = "Lấy thông tin thành công",
            Data = result
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AttributeValueRequestDto model)
    {
        var result = await _attributeValueServices.CreateAsync(model);
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
        var result = await _attributeValueServices.DeleteAsync(id);
        if (result)
            return Ok(new ResponseBase());
        return BadRequest(new ResponseBase
        {
            Message = "Xoá không thành công"
        });
    }
    [HttpPut]
    public async Task<IActionResult> Update(int id ,AttributeValueRequestDto model)
    {
        var result = await _attributeValueServices.UpdateAsync(model,id);
        if (result)
            return Ok(new ResponseBase());
        return BadRequest(new ResponseBase
        {
            Message = "Sửa không thành công"
        });
    }
}