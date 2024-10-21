using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.Services.User.Commands.CreateUser
{
    public sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand,Guid?>
    {
        private readonly IUserRepository<AppUser> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository<AppUser> userRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request.CreateUserRequest);
            user.Image = request.CreateUserRequest.PathImage;
            var result =await _userRepository.AddAsync(user);
            var resultAddRole = await _userRepository.AddRoleInUser(request.CreateUserRequest.Roles,user);
            
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }


        
    }
}
