using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    private SuperMarketDbContext _dataContext;
    protected IDbFactory DbFactory { get; }
    protected SuperMarketDbContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());
    public CategoryRepository(IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
    {
        DbFactory = dbFactory;
    }
    public async Task<Category> UpdateAsyncCategory(Category entity, Guid id, string entityType, Guid userId)
    {
        var entityResult = await DbContext.Categories.FirstOrDefaultAsync(x => x.Id == id && x.IsDelete == false);
        if (entityResult == null)
            return null;
        entityResult.Name = entity.Name;
        entityResult.Describe = entity.Describe;
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