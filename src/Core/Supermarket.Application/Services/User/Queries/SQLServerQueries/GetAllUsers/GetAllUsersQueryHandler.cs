using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.Services.User.Queries.SQLServerQueries.GetAllUsers
{
    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponseDto>>
    {
        private readonly IUserRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository<AppUser> userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAll();
            var resultMap = new List<UserResponseDto>();
            foreach (var user in result)
            {
                var role = await _userRepository.GetRolesByUserAsync(user);
                var userMap = _mapper.Map<UserResponseDto>(user);
                userMap.Roles = _mapper.Map<IEnumerable<RoleResponseDto>>(role);
                resultMap.Add(userMap);
            }
            return resultMap;
        }
    }
}
