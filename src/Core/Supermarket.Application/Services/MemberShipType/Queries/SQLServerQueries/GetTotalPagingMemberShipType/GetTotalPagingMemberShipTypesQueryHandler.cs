using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetTotalPagingMemberShipType
{
    public class GetTotalPagingMemberShipTypesQueryHandler : IRequestHandler<GetTotalPagingMemberShipTypesQuery,int>
    {
        private readonly IMemberShipTypeRepository _memberShipTypeRepository;

        private readonly IEmployeeRepository _employeeRepository;
        public GetTotalPagingMemberShipTypesQueryHandler( IMemberShipTypeRepository memberShipTypeRepository)
        {
            _memberShipTypeRepository = memberShipTypeRepository;
        }
        public async Task<int> Handle(GetTotalPagingMemberShipTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _memberShipTypeRepository.CountAsync(x => x.IsDelete == false);
            decimal total = Math.Ceiling((decimal)result / request.size);
            return (int)total;

        }
    }
}
