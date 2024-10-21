using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Coupon.Commands.CreateCoupon
{
    public sealed class CreateCouponCommandHandler : ICommandHandler<CreateCouponCommand, Guid?>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCouponCommandHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _couponRepository = couponRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid?> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            var entityMap = _mapper.Map<Domain.Entities.SupermarketEntities.Coupon>(request.CreateCouponRequest);
            var result = await _couponRepository.AddAsync(entityMap, request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
        
    }
}
