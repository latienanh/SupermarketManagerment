using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.Services.Employee.Commands.CreateEmployee;
using Supermarket.Application.Services.Employee.Commands.UpdateEmployee;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Mapper;

public class EmployeeMapper : Profile
{
    public EmployeeMapper()
    {
        CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();
        CreateMap<Employee, EmployeeResponseDto>().ReverseMap();

    }
}