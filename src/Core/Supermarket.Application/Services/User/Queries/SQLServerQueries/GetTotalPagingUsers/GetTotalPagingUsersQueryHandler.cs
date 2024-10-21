using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.Services.User.Queries.SQLServerQueries.GetTotalPagingUsers
{
    public class GetTotalPagingUsersQueryHandler : IRequestHandler<GetTotalPagingUsersQuery,int>
    {
        private readonly IUserRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public GetTotalPagingUsersQueryHandler(IUserRepository<AppUser> userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }
        public async Task<int> Handle(GetTotalPagingUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetTotalPagingAsync(request.size);
            return result;

        }
    }
}
