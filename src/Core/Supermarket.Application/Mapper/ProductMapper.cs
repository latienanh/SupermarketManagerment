using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.Services.Product.Commands.CreateProduct;
using Supermarket.Application.Services.Product.Commands.UpdateProduct;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Mapper;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<VariantValue, VariantValueResponse>().ReverseMap();
        CreateMap<Product, CreateProductRequest>().ReverseMap();
        CreateMap<Product, UpdateProductRequest>().ReverseMap();
        CreateMap<Product, ProductResponseDto>().ReverseMap();

        CreateMap<Product, VariantRequestDto>().ReverseMap().ForMember(dest => dest.VariantValues, opt => opt.Ignore());
        CreateMap<Product, ProductsPagingResponseDto>().ReverseMap();
    }
}