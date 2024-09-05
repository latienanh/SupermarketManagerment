using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Coupon.Commands.DeleteCoupon
{
    internal class DeleteCouponCommandHandler : IRequestHandler<DeleteCouponCommand,Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public DeleteCouponCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,IProductRepository productRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public async Task<Guid?> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteAsync(request.DeleteCouponRequest.Id,request.UserId);
            if(result==null) return null;
            return result.Id;
        }
    }
}
