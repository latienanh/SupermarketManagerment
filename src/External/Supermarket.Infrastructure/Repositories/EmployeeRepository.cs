using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Infrastructure.DbContext;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private SuperMarketDbContext _dataContext;
        protected IDbFactory DbFactory { get; }
        protected SuperMarketDbContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());
        public EmployeeRepository(IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
        {
            DbFactory = dbFactory;
        }

        public async Task<Employee> updateEmployee(Employee entity, string entityType, Guid userId)
        {
            var entityResult = await DbContext.Employees.FirstOrDefaultAsync(x => x.Id == entity.Id && x.IsDelete == false);
            if (entityResult == null)
                return null;
            entityResult.Email= entity.Email;
            entityResult.FirstName = entity.FirstName;
            entityResult.LastName = entity.LastName;
            entityResult.Address = entity.Address;
            entityResult.PhoneNumber = entity.PhoneNumber;
            if (entity.Image != null)
            {
                entityResult.Image = entity.Image;
            }
            var updateModifed = new Modification()
            {
                ModifiedBy = userId,
                ModifiedTime = DateTime.UtcNow,
                EntityId = entityResult.Id,
                EntityType = entityType
            };
            DbContext.Modifications.Add(updateModifed);
            return entityResult;
        }
    }

}
