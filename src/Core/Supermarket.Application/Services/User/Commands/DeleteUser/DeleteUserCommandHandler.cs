using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.Services.User.Commands.DeleteUser
{
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository<AppUser> _userRepository;

        public DeleteUserCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,IUserRepository<AppUser> userRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
         
        }
        public async Task<Guid?> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.DeleteAsync(request.DeleteUserRequest.Id);
            if (result == null)
                return null;
            return result.Id;
        }
    }
}
