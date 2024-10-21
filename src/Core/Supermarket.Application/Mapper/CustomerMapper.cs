using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.Services.Customer.Commands.CreateCustomer;
using Supermarket.Application.Services.Customer.Commands.UpdateCustomer;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Mapper;

public class CustomerMapper : Profile
{
    public CustomerMapper()
    {
        CreateMap<Customer, CreateCustomerRequest>().ReverseMap();
        CreateMap<Customer, UpdateCustomerRequest>().ReverseMap();
        CreateMap<Customer, CustomerResponseDto>().ReverseMap();
    }
}