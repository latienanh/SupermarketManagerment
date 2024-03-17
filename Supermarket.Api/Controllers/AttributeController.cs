using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IServices;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _attributeServices.GetByIdAsync(Id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AttributeDto attributeDto)
        {
            var result = await _attributeServices.CreateAsync(attributeDto);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(AttributeDto attributeDto,int Id)
        {
            var result = await _attributeServices.UpdateAsync(attributeDto,Id);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete( int Id)
        {
            var result = await _attributeServices.DeleteAsync( Id);
            return Ok(result);
        }

    }
}
