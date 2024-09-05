using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Domain.Abstractions.IRepositories
{
    public interface IEmployeeRepository : IEntityRepository<Employee>
    {
        Task<Employee> updateEmployee(Employee entity, string entityType, Guid userId);
    }
}
