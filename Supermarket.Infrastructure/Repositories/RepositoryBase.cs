using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.Common;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepository<T> where T : BaseDomain
{
    private readonly IMapper _mapper;

    protected RepositoryBase(IDbFactory dbFactory,IMapper mapper)
    {
        _mapper = mapper;
        DbFactory = dbFactory;
        dbSet = DbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        if (entity == null) return null;
        entity.CreateTime= DateTime.UtcNow;
        entity.IsDelete = false;
        await dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity,int id,string entityType)
    {
        var entitySet = await DbContext.Set<T>().FirstOrDefaultAsync(x=>x.Id==id);
        var entityToUpdate = entitySet;
        
        var properties = typeof(T).GetProperties().Where(x => x.Name != "IsDelete"&& x.Name != "CreateBy" && x.Name != "CreateTime" && x.Name != "DeleteBy");
            
        foreach (var property in properties)
        {
            property.SetValue(entityToUpdate, property.GetValue(entity));
        }
        entityToUpdate.Id=id;
        var updateModifed = new ModificationDto
        {
            ModifiedBy = null,
            ModifiedTime = DateTime.UtcNow,
            EntityId = entityToUpdate.Id,
            EntityType = entityType
        };
        var mapperUpdateM = _mapper.Map<Modification>(updateModifed);
        DbContext.Modifications.Add(mapperUpdateM);
        dbSet.Update(entityToUpdate);

        return entityToUpdate;
        //dbSet.Attach(entity);
        //DbContext.Entry(entity).State = EntityState.Modified;
        //return entity;
    }

    public Task<T> DeleteAsync(T entity)
    {
        //return dbSet.Remove(entity);
        throw new NotImplementedException();
    }

    public async Task<T> DeleteAsync(int id)
    {
        var entity = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return null;
        entity.IsDelete = true;
        return entity;
    }

    public async Task<bool> DeleteMultiAsync(Expression<Func<T, bool>> where)
    {
        var objects = dbSet.Where(where).AsEnumerable();
        foreach (var obj in objects)
            obj.IsDelete = true;
        return true;
    }

    public async Task<T> GetSingleByIdAsync(int id)
    {
        return await dbSet.FirstOrDefaultAsync(x => x.Id == id&&x.IsDelete==true);
    }

    public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        if (includes != null && includes.Count() > 0)
        {
            var query = dataContext.Set<T>().Include(includes.First());
            foreach (var include in includes.Skip(1))
                query = query.Include(include);
            return await query.FirstOrDefaultAsync(expression);
        }

        return await dataContext.Set<T>().FirstOrDefaultAsync(expression);
    }


    public async Task<IEnumerable<T>> GetAllAsync(string[] includes = null)
    {
        if (includes != null && includes.Count() > 0)
        {
            var query = dataContext.Set<T>().Include(includes.First());
            foreach (var include in includes.Skip(1))
                query = query.Include(include);
            return query.AsQueryable();
        }

        return dataContext.Set<T>().Where(x=>x.IsDelete==false).AsQueryable();
    }

    public async Task<IEnumerable<T>> GetMultiAsync(Expression<Func<T, bool>> predicate, string[] includes = null)
    {
        //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        if (includes != null && includes.Count() > 0)
        {
            var query = dataContext.Set<T>().Include(includes.First());
            foreach (var include in includes.Skip(1))
                query = query.Include(include);
            return query.Where(predicate).AsQueryable();
        }

        return dataContext.Set<T>().Where(predicate).AsQueryable();
    }

    public async Task<IEnumerable<T>> GetMultiPagingAsync(Expression<Func<T, bool>> predicate, int total, int index = 0,
        int size = 50, string[] includes = null)
    {
        var skipCount = index * size;
        IQueryable<T> _resetSet;

        //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        if (includes != null && includes.Count() > 0)
        {
            var query = dataContext.Set<T>().Include(includes.First());
            foreach (var include in includes.Skip(1))
                query = query.Include(include);
            _resetSet = predicate != null ? query.Where(predicate).AsQueryable() : query.AsQueryable();
        }
        else
        {
            _resetSet = predicate != null
                ? dataContext.Set<T>().Where(predicate).AsQueryable()
                : dataContext.Set<T>().AsQueryable();
        }

        _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
        total = _resetSet.Count();
        return _resetSet.AsQueryable();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> where)
    {
        return dbSet.Count(where);
    }

    public async Task<bool> CheckContainsAsync(Expression<Func<T, bool>> predicate)
    {
        return dataContext.Set<T>().Count(predicate) > 0;
    }

    #region Properties

    private SuperMarketDbContext dataContext;
    private readonly DbSet<T> dbSet;

    protected IDbFactory DbFactory { get; }

    protected SuperMarketDbContext DbContext => dataContext ?? (dataContext = DbFactory.Init());

    #endregion
}