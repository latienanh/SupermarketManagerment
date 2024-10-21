using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.Services.Coupon.Commands.CreateCoupon;
using Supermarket.Application.Services.Coupon.Commands.UpdateCoupon;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Mapper;

public class CouponMapper : Profile
{
    public CouponMapper()
    {
        CreateMap<Coupon, CreateCouponRequest>().ReverseMap();
        CreateMap<Coupon, UpdateCouponRequest>().ReverseMap();
        CreateMap<Coupon, CouponResposeDto>().ReverseMap();
    }
}