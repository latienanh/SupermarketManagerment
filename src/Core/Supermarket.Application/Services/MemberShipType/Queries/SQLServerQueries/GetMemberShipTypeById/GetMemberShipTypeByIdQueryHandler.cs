using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetMemberShipTypeById
{
    public class GetMemberShipTypeByIdQueryHandler: IRequestHandler<GetMemberShipTypeByIdQuery,MemberShipTypeResposeDto>
    {
        private readonly IMemberShipTypeRepository _memberShipTypeRepository;
        private readonly IMapper _mapper;

        public GetMemberShipTypeByIdQueryHandler(IMemberShipTypeRepository memberShipTypeRepository,
            IMapper mapper)
        {
            _memberShipTypeRepository = memberShipTypeRepository;
            _mapper = mapper;

        }
        public async Task<MemberShipTypeResposeDto> Handle(GetMemberShipTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _memberShipTypeRepository.GetSingleByIdAsync(request.id);
            return _mapper.Map<MemberShipTypeResposeDto>(result);
        }
    }
}
