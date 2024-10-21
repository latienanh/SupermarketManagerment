using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.Services.Supplier.Commands.CreateSupplier;
using Supermarket.Application.Services.Supplier.Commands.UpdateSupplier;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Mapper;

public class SupplierMapper : Profile
{
    public SupplierMapper()
    {
        CreateMap<Supplier, SupplierResponseDto>().ReverseMap();
        CreateMap<Supplier, CreateSupplierRequest>().ReverseMap();
        CreateMap<Supplier, UpdateSupplierRequest>().ReverseMap();
    }
}