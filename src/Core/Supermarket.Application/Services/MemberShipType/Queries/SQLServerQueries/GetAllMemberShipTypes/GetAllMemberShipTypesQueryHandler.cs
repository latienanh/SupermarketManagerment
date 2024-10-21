using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetAllMemberShipTypes
{
    internal class GetAllMemberShipTypesQueryHandler : IRequestHandler<GetAllMemberShipTypesQuery, IEnumerable<MemberShipTypeResposeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMemberShipTypeRepository _memberShipTypeRepository;
        public GetAllMemberShipTypesQueryHandler(IMapper mapper, IMemberShipTypeRepository memberShipTypeRepository)
        {
            _mapper = mapper;
            _memberShipTypeRepository = memberShipTypeRepository;
        }
        public async Task<IEnumerable<MemberShipTypeResposeDto>> Handle(GetAllMemberShipTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _memberShipTypeRepository.GetMultiAsync(x => x.IsDelete == false);
            if (result != null)
            {
                var resultMap = _mapper.Map<IEnumerable<MemberShipTypeResposeDto>>(result);
                return resultMap;
            }

            return null;
        }
    }
}
