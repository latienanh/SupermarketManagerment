using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
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
        CreateMap<Category, CategoriesPagingResponseDto>().ReverseMap();
        CreateMap<AppUser, UserRequestDto>().ReverseMap();
        CreateMap<AppUser, SignUpRequestDto>().ReverseMap();
        CreateMap<AppUser, UserUpdateRequestDto>().ReverseMap();
        CreateMap<Attribute, AttributeResponseDto>().ReverseMap();
        CreateMap<Attribute, AttributeRequestDto>().ReverseMap();
        CreateMap<Modification, ModificationDto>().ReverseMap();
        CreateMap<VariantValue,VariantValueResponse>().ReverseMap();
        CreateMap<IdentityRole<Guid>, RoleRequestDto>().ReverseMap();
        CreateMap<IdentityRole<Guid>, RoleResponseDto>().ReverseMap();
        CreateMap<AppUser, UserResponseDto>().ReverseMap();
        CreateMap<Product, ProductRequestDto>().ReverseMap();
        CreateMap<Product, ProductResponseDto>().ReverseMap();
        CreateMap<Product, VariantRequestDto>().ReverseMap().ForMember(dest => dest.VariantValues, opt => opt.Ignore());
        CreateMap<Product, ProductsPagingResponseDto>().ReverseMap();
        CreateMap<Coupon, CouponRequestDto>().ReverseMap();
        CreateMap<Coupon, CouponResposeDto>().ReverseMap();
        CreateMap<Customer, CustomerRequestDto>().ReverseMap();
        CreateMap<Customer, CustomerResponseDto>().ReverseMap();
        CreateMap<MemberShipType, MemberShipTypeRequestDto>().ReverseMap();
        CreateMap<MemberShipType, MemberShipTypeResposeDto>().ReverseMap();
        CreateMap<Supplier, SupplierResponseDto>().ReverseMap();
        CreateMap<Supplier, SupplierRequestDto>().ReverseMap();
        CreateMap<Employee, EmployeeResponseDto>().ReverseMap();
        CreateMap<Employee, EmployeeRequestDto>().ReverseMap();
        CreateMap<StockIn,ImportGoodsRequest>().ReverseMap().ForMember(dest => dest.StockInDetails, opt => opt.Ignore());
        CreateMap<StockInDetail, StockInDetailRequest>().ReverseMap();
        CreateMap<Invoice, InvoiceRequestDto>().ReverseMap().ForMember(dest => dest.InvoiceDetails, opt => opt.Ignore());
        CreateMap<InvoiceDetail, InvoiceDetailRequest>().ReverseMap();
    }
}