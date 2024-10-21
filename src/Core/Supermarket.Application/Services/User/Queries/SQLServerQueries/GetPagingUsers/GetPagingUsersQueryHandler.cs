using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.Services.User.Queries.SQLServerQueries.GetPagingUsers
{
    public class GetPagingUsersQueryHandler : IRequestHandler<GetPagingUsersQuery, IEnumerable<UserResponseDto>>
    {
        private readonly IUserRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public GetPagingUsersQueryHandler(IUserRepository<AppUser> userRepository,
            IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<UserResponseDto>> Handle(GetPagingUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetMultiPagingAsync( request.size, request.index);
            var resultMap = _mapper.Map<IEnumerable<UserResponseDto>>(result);
            return resultMap;
        }
    }
}
