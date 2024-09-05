using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.Services.User.Commands.UpdateUser
{
    public sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand,Guid?>
    {
        private readonly IUserRepository<AppUser> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository<AppUser> userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Guid?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request.UpdateUserRequest);
            user.Image = request.UpdateUserRequest.PathImage;
            var result = await _userRepository.AddAsync(user);
            var resultAddRole = await _userRepository.AddRoleInUser(request.UpdateUserRequest.Roles, user);
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
