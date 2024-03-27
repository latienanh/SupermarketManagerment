using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IServices;
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

    // GET: api/<CategoriesController>
    [HttpGet]
    //[Authorize(Roles = "Salesperson")]
    public ActionResult<IList<CategoryDto>> Get()
    {
        var allCategories = _categoryServices.GetAllCategories();
        return Ok(allCategories);
    }


    // GET api/<CategoriesController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    [HttpPost]
    //[Authorize(Roles = "Administrator")]
    public ActionResult<Category> Create(CategoryDto categoryDto)
    {
        _categoryServices.createCategory(categoryDto);
        if (categoryDto != null)
            return Ok(new
            {
                Success = true,
                Data = categoryDto
            });

        return BadRequest();
    }

    // PUT api/<CategoriesController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<CategoriesController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}