
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.IRepositories
{
    public interface IEmployeeRepository : IEntityRepository<Employee>
    {
        Task<Employee> updateEmployee(Employee entity, Guid id, string entityType, Guid userId);
    }
}
