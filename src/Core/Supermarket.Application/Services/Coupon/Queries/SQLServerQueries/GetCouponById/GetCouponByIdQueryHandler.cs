using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetCouponById
{
    public class GetCouponByIdQueryHandler: IRequestHandler<GetCouponByIdQuery,CouponResposeDto>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;


        public GetCouponByIdQueryHandler(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }
        public async Task<CouponResposeDto> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _couponRepository.GetSingleByIdAsync(request.id);

            return _mapper.Map<CouponResposeDto>(result);
        }
    }
}
