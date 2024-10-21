using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.Services.User.Queries.SQLServerQueries.GetUserById
{
    public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQuery,UserResponseDto>
    {
        private readonly IUserRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository<AppUser> userRepository,
            IMapper mapper)
        {

            _userRepository = userRepository;
            _mapper = mapper;

        }
        public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByIdAsync(request.id);
            var resultMap = _mapper.Map<UserResponseDto>(result);
            resultMap.Roles = _mapper.Map<IEnumerable<RoleResponseDto>>(await _userRepository.GetRolesByUserAsync(result)) ;
            return resultMap;
        }
    }
}
