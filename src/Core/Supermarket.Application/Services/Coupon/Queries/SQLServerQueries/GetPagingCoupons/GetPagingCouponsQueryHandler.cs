using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetPagingCoupons
{
    public class GetPagingCouponsQueryHandler : IRequestHandler<GetPagingCouponsQuery, IEnumerable<CouponResposeDto>>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;


        public GetPagingCouponsQueryHandler(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CouponResposeDto>> Handle(GetPagingCouponsQuery request, CancellationToken cancellationToken)
        {
            var result = await _couponRepository.GetMultiPagingAsync(x => x.IsDelete == false, request.index, request.size);
            var resultMap = _mapper.Map<IEnumerable<CouponResposeDto>>(result);
            return resultMap;
        }
    }
}
