using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetTotalPagingCoupons
{
    public class GetTotalPagingCouponsQueryHandler : IRequestHandler<GetTotalPagingCouponsQuery,int>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;


        public GetTotalPagingCouponsQueryHandler(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(GetTotalPagingCouponsQuery request, CancellationToken cancellationToken)
        {
            var result = await _couponRepository.CountAsync(x => x.IsDelete == false);
            decimal total = Math.Ceiling((decimal)result / request.size);
            return (int)total;

        }
    }
}
