using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.Services.Authentication.Commands.Register;
using Supermarket.Application.Services.User.Commands.CreateUser;
using Supermarket.Application.Services.User.Commands.UpdateUser;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.Mapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<AppUser, CreateUserRequest>().ReverseMap();
        CreateMap<AppUser, UpdateUserRequest>().ReverseMap();
        CreateMap<AppUser, RegisterRequest>().ReverseMap();
        CreateMap<IdentityRole<Guid>, RoleRequestDto>().ReverseMap();
        CreateMap<IdentityRole<Guid>, RoleResponseDto>().ReverseMap();
        CreateMap<AppUser, UserResponseDto>().ReverseMap();
    }
}