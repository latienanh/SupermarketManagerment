using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Authentication.Commands.Logout
{
    internal class LogoutCommandHandler : IRequestHandler<LogoutCommand,Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public LogoutCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,IRefreshTokenRepository refreshTokenRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<Guid?> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var currentTime = DateTime.UtcNow;
            var refreshToken = await _refreshTokenRepository.GetByIdAsync(request.LogoutRequest.Id);
            if (refreshToken == null || refreshToken.Expriaton < currentTime)
            {
                // Refresh token không tồn tại hoặc đã hết hạn, không cần xóa
                return null;
            } 
            await _refreshTokenRepository.DeleteAsync(refreshToken.Id);
            await _unitOfWork.CommitAsync(cancellationToken);
            return refreshToken.Id ;
        }
    }
}
