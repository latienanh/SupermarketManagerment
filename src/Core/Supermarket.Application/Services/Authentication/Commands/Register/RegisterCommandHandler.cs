using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.Abstractions.Token;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Entities.Common;

namespace Supermarket.Application.Services.Authentication.Commands.Register
{
    public sealed class RegisterCommandHandler: ICommandHandler<RegisterCommand,Guid?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ITokenCommand _tokenCommand;
        private readonly ITokenQuery _tokenQuery;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public RegisterCommandHandler(IUnitOfWork unitOfWork, UserManager<AppUser> userManager,

            SignInManager<AppUser> signInManager,

            RoleManager<IdentityRole<Guid>> roleManager,
            ITokenCommand tokenCommand,
            ITokenQuery tokenQuery)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenCommand = tokenCommand;
            _tokenQuery = tokenQuery;

        }
        public async Task<Guid?> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
                //if (signUpRequestDto.Password != signUpRequestDto.ConfirmPassword)
                //{
                //    return IdentityResult.Failed(new IdentityError { Code = "PasswordConfirmation", Description = "Passwords không giống." });
                //}
                var user = _mapper.Map<AppUser>(request.registerRequest);
                user.Image = request.registerRequest.PathImage;
                user.PasswordHash = request.registerRequest.Password;
                var result = await _userManager.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(RoleBase.Cashier))
                        await _roleManager.CreateAsync(new IdentityRole<Guid>(RoleBase.Cashier));

                    await _userManager.AddToRoleAsync(user, RoleBase.Cashier);
                    await _unitOfWork.CommitAsync(cancellationToken);
                    return user.Id;
                }
                return null;
        }
    }
}
