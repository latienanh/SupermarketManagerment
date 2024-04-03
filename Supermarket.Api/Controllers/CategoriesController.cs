using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;
using Supermarket.Domain.Entities.SupermarketEntities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Supermarket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryServices _categoryServices;

    public CategoriesController(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryServices.GetAllAsync();
        if (result.IsNullOrEmpty())
            return BadRequest(new ResponseWithList<CategoryResponseDto>
                {
                    Message = "Không có thông tin gì",
                    ListData = result
                }
            );
        return Ok(new ResponseWithList<CategoryResponseDto>
        {
            Message = "Lấy thông tin thành công",
            ListData = result
        });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _categoryServices.GetByIdAsync(id);
        if (result == null)
            return BadRequest(new ResponseWithData<CategoryResponseDto>
                {
                    Message = "Không có thông tin gì",
                    Data = result
                }
            );
        return Ok(new ResponseWithData<CategoryResponseDto>
        {
            Message = "Lấy thông tin thành công",
            Data = result
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryRequestDto model)
    {
        var result = await _categoryServices.CreateAsync(model);
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
        var result = await _categoryServices.DeleteAsync(id);
        if (result)
            return Ok(new ResponseBase());
        return BadRequest(new ResponseBase
        {
            Message = "Xoá không thành công"
        });
    }
    [HttpPut]
    public async Task<IActionResult> Update(int id, CategoryRequestDto model)
    {
        var result = await _categoryServices.UpdateAsync(model, id);
        if (result)
            return Ok(new ResponseBase());
        return BadRequest(new ResponseBase
        {
            Message = "Sửa không thành công"
        });
    }
}