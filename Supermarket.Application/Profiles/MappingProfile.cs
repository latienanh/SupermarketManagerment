using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Entities.SupermarketEntities;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryResponseDto>().ReverseMap();
        CreateMap<Category, CategoryRequestDto>().ReverseMap();
        CreateMap<AppUser, UserRequestDto>().ReverseMap();
        CreateMap<Attribute, AttributeResponseDto>().ReverseMap();
        CreateMap<Attribute, AttributeRequestDto>().ReverseMap();
        CreateMap<Modification, ModificationDto>().ReverseMap();
        CreateMap<VariantValue, AttributeValueResponseDto>().ReverseMap();
        CreateMap<VariantValue, AttributeValueRequestDto>().ReverseMap();
        CreateMap<IdentityRole<Guid>, RoleRequestDto>().ReverseMap();
        CreateMap<IdentityRole<Guid>, RoleResponseDto>().ReverseMap();
        CreateMap<AppUser, UserResponseDto>().ReverseMap();
        CreateMap<Product, ProductRequestDto>().ReverseMap();
        CreateMap<Product, ProductResponseDto>().ReverseMap();
        CreateMap<Product,VariantRequestDto>().ReverseMap();
        CreateMap<Coupon,CouponRequestDto>().ReverseMap();
        CreateMap<Coupon,CouponResposeDto>().ReverseMap();
    }
}