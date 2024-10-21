using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.Services.Category.Commands.CreateCategory;
using Supermarket.Application.Services.Category.Commands.UpdateCategory;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Mapper;

public class CategoryMapper : Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CreateCategoryRequest>().ReverseMap();
        CreateMap<Category, UpdateCategoryRequest>().ReverseMap();

        CreateMap<Category, CategoryResponseDto>().ReverseMap();
        CreateMap<Category, CategoriesPagingResponseDto>().ReverseMap();
    }
}