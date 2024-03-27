using System.Net;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

//[Authorize]
public class AttributeController : ControllerBase
{
    private readonly IAttributeServices _attributeServices;

    public AttributeController(IAttributeServices attributeServices)
    {
        _attributeServices = attributeServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _attributeServices.GetAllAsync();
        if (result.Any())
            return Ok(new ResponseWithList<AttributeDto>
            {
                Message = "Tìm thấy thành công",
                ListData = result
            });
        return BadRequest(new ResponseWithList<AttributeDto>
        {
            Status = HttpStatusCode.BadRequest,
            Message = "Không tìm thấy thông tin",
            ListData = result
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _attributeServices.GetByIdAsync(id);
        if (result != null)
            return Ok(new ResponseWithData<AttributeDto>
            {
                Data = result
            });
        return BadRequest(new ResponseWithData<AttributeDto>
        {
            Status = HttpStatusCode.BadRequest,
            Message = "Không tìm thấy thông tin",
            Data = result
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(AttributeDto attributeDto)
    {
        var result = await _attributeServices.CreateAsync(attributeDto);
        //if (result)
        return Created("", result);
        //return BadRequest(new ResponseWithData<AttributeDto>()
        //{
        //    Data = result
        //});
    }

    [HttpPut]
    public async Task<IActionResult> Update(AttributeDto attributeDto, int Id)
    {
        var result = await _attributeServices.UpdateAsync(attributeDto, Id);
        //if (result)
        return Ok(
            result
        );
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int Id)
    {
        var result = await _attributeServices.DeleteAsync(Id);
        return Ok(
            result
        );
    }
}