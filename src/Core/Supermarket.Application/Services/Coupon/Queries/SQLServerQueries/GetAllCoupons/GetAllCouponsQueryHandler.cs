using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetAllCoupons
{
    public class GetAllCouponsQueryHandler : IRequestHandler<GetAllCouponsQuery, IEnumerable<CouponResposeDto>>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;


        public GetAllCouponsQueryHandler(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CouponResposeDto>> Handle(GetAllCouponsQuery request, CancellationToken cancellationToken)
        {
            var result = await _couponRepository.GetAllAsync();
            var couponMap = _mapper.Map<IEnumerable<CouponResposeDto>>(result);
            return couponMap;
        }
    }
}
