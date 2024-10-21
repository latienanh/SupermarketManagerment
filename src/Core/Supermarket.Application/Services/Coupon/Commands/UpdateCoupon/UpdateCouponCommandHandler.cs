using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Coupon.Commands.UpdateCoupon
{
    public class UpdateCouponCommandHandler : ICommandHandler<UpdateCouponCommand, Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICouponRepository _couponRepository;

        public UpdateCouponCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICouponRepository couponRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _couponRepository = couponRepository;
        }
        public async Task<Guid?> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
        {
            var entityMap = _mapper.Map<Domain.Entities.SupermarketEntities.Coupon>(request.UpdateCouponRequest);
            var result = await _couponRepository.UpdateAsync(entityMap, "Coupon", request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
