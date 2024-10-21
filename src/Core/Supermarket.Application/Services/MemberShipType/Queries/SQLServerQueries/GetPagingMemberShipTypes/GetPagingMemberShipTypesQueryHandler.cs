using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetPagingMemberShipTypes
{
    public class GetPagingMemberShipTypesQueryHandler : IRequestHandler<GetPagingMemberShipTypesQuery, IEnumerable<MemberShipTypeResposeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMemberShipTypeRepository _memberShipTypeRepository;
        
        public GetPagingMemberShipTypesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IMemberShipTypeRepository memberShipTypeRepository)
        {
            _mapper = mapper;
            _memberShipTypeRepository = memberShipTypeRepository;
         
        }
        public async Task<IEnumerable<MemberShipTypeResposeDto>> Handle(GetPagingMemberShipTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _memberShipTypeRepository.GetMultiPagingAsync(x => x.IsDelete == false, request.index, request.size);
            var resultMap = _mapper.Map<IEnumerable<MemberShipTypeResposeDto>>(result);
            return resultMap;
        }
    }
}
