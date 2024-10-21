using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.Services.Inventory.Commands.ImportGoods;
using Supermarket.Application.Services.Inventory.Commands.Sale;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Mapper;

public class InventoryMapper : Profile
{
    public InventoryMapper()
    {
        CreateMap<StockIn, ImportGoodsRequest>().ReverseMap().ForMember(dest => dest.StockInDetails, opt => opt.Ignore());
        CreateMap<StockInDetail, StockInDetailRequest>().ReverseMap();
        CreateMap<Invoice, InvoiceRequest>().ReverseMap().ForMember(dest => dest.InvoiceDetails, opt => opt.Ignore());
        CreateMap<InvoiceDetail, InvoiceDetailRequest>().ReverseMap();
        CreateMap<Invoice, InvoiceResponseDto>().ReverseMap();
        CreateMap<StockIn, StockInResponseDto>().ReverseMap();
        CreateMap<InvoiceDetail, InvoiceDetailResponseDto>().ReverseMap();
    }
}