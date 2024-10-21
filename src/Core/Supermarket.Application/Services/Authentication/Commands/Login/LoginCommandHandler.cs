using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.Abstractions.Token;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Entities.Token;

namespace Supermarket.Application.Services.Authentication.Commands.Login
{
    public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly ITokenCommand _tokenCommand;
        private readonly ITokenQuery _tokenQuery;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<AppUser> _userManager;

        public LoginCommandHandler(IUnitOfWork unitOfWork, UserManager<AppUser> userManager,

            SignInManager<AppUser> signInManager,
            IRefreshTokenRepository refreshTokenRepository,
            RoleManager<IdentityRole<Guid>> roleManager,
            ITokenCommand tokenCommand,
            ITokenQuery tokenQuery)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _refreshTokenRepository = refreshTokenRepository;
            _roleManager = roleManager;
            _tokenCommand = tokenCommand;
            _tokenQuery = tokenQuery;
           
        }
        public async Task<LoginResponse?> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.LoginRequest.UserName);
            if (user == null)
                return null;
            var passwordValid = await _userManager.CheckPasswordAsync(user, request.LoginRequest.Password);
            if (user == null || !passwordValid)
                return null;
            var token = await _tokenQuery.GenerateAccessTokenAsync(user);
            var refreshTokenDatabase = await _refreshTokenRepository.GetByUserIdAsync(user.Id);
            if (refreshTokenDatabase == null)
            {
                var refreshTokenNew = new RefreshToken
                {
                    Token = await _tokenCommand.GenerateRefreshTokenAsync(),
                    Expriaton = DateTime.UtcNow.AddDays(30), //30 ngay
                    UserId = user.Id
                };
                await _tokenCommand.CreateRefreshTokenAsync(refreshTokenNew);
                await _unitOfWork.CommitAsync(cancellationToken);
                return new LoginResponse()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshTokenNew.Token,
                };
            }
            if (refreshTokenDatabase.Expriaton < DateTime.UtcNow)
            {
                var refreshTokenNew = new RefreshToken
                {
                    Token = await _tokenCommand.GenerateRefreshTokenAsync(),
                    Expriaton = DateTime.UtcNow.AddDays(30),//30 ngay
                    UserId = user.Id
                };
                await _tokenCommand.UpdateRefreshTokenAsync(refreshTokenNew, refreshTokenDatabase.Id);
                await _unitOfWork.CommitAsync(cancellationToken);
                return new LoginResponse()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),

                    RefreshToken = refreshTokenNew.Token,

                };
            }

            return new LoginResponse()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),

                RefreshToken = refreshTokenDatabase.Token,

            };

        }
    }
}