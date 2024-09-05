using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Primitives;
using Supermarket.Infrastructure.DbContext;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IEntityRepository<T> where T : Entity
{
    #region Properties
    private readonly IMapper _mapper;
    private SuperMarketDbContext _dataContext;
    private readonly DbSet<T> _dbSet;
    protected IDbFactory DbFactory { get; }
    protected SuperMarketDbContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

    #endregion
    protected RepositoryBase(IDbFactory dbFactory, IMapper mapper)
    {
        _mapper = mapper;
        DbFactory = dbFactory;
        _dbSet = DbContext.Set<T>();
    }

    public async Task<T?> AddAsync(T entity, Guid userId)
    {
        if (entity == null) return null;
        try
        {
            entity.CreateTime = DateTime.UtcNow;
            entity.CreateBy = userId;
            entity.IsDelete = false;
            await _dbSet.AddAsync(entity);
            return entity;
        }
        catch (Exception ex)
        {
            // Xử lý ngoại lệ nếu có
            // Có thể ghi log, hoặc trả về một giá trị khác để biểu thị lỗi
            Console.WriteLine(ex.Message);
            return null;
        }
    }

   

    public async Task<T?> UpdateAsync(T entity, string entityType, Guid userId)
    {
        var entitySet = await DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id&&x.IsDelete==false);
        if (entitySet == null)
            return null;

        var properties = typeof(T).GetProperties().Where(x => x.Name != "IsDelete" && x.Name != "CreateBy" && x.Name != "CreateTime" && x.Name != "DeleteBy"&&x.Name!="Id");

        foreach (var property in properties)
        {
            property.SetValue(entitySet, property.GetValue(entity));
        }
        var updateModifed = new Modification()
        {
            ModifiedBy = userId,
            ModifiedTime = DateTime.UtcNow,
            EntityId = entitySet.Id,
            EntityType = entityType
        };
        //var mapperUpdateM = _mapper.Map<Modification>(updateModifed);
        DbContext.Modifications.Add(updateModifed);
        return entitySet;
    }

    public Task<T> DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<T?> DeleteAsync(Guid id, Guid userId)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return null;
        entity.IsDelete = true;
        entity.DeleteBy=userId;
        return entity;
    }

    public async Task<bool> DeleteMultiAsync(Expression<Func<T, bool>> where)
    {
        var objects = _dbSet.Where(where).AsEnumerable();
        foreach (var obj in objects)
            obj.IsDelete = true;
        return true;
    }

   

    public async Task<T?> GetSingleByIdAsync(Guid? id)
    {
        if(id == null)
            return null;
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsDelete == false);
    }

    public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, string[]? includes )
    {
        if (includes != null && includes.Count() > 0)
        {
            var query = _dataContext.Set<T>().Include(includes.First());
            foreach (var include in includes.Skip(1))
                query = query.Include(include);
            return await query.FirstOrDefaultAsync(expression);
        }

        return await _dataContext.Set<T>().FirstOrDefaultAsync(expression);
    }


    public async Task<IEnumerable<T>> GetAllAsync(string[]? includes)
    {
        if (includes != null && includes.Count() > 0)
        {
            var query = _dataContext.Set<T>().Include(includes.First());
            foreach (var include in includes.Skip(1))
                query = query.Include(include);
            return query.AsQueryable();
        }

        return _dataContext.Set<T>().Where(x => x.IsDelete == false).AsQueryable();
    }

    public async Task<IEnumerable<T>> GetMultiAsync(Expression<Func<T, bool>> predicate, string[]? includes)
    {
        //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        if (includes != null && includes.Count() > 0)
        {
            var query = _dataContext.Set<T>().Include(includes.First());
            foreach (var include in includes.Skip(1))
                query = query.Include(include);
            return query.Where(predicate).AsQueryable();
        }

        return _dataContext.Set<T>().Where(predicate).AsQueryable();
    }

    public async Task<IEnumerable<T>> GetMultiPagingAsync(Expression<Func<T, bool>> predicate, int index = 0, int size = 50, string[]? includes =null)
    {
    
        var skipCount = index * size;
        IQueryable<T> _resetSet;

        //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        if (includes != null && includes.Count() > 0)
        {
            var query = _dataContext.Set<T>().Include(includes.First());
            foreach (var include in includes.Skip(1))
                query = query.Include(include);
            _resetSet = predicate != null ? query.Where(predicate).AsQueryable() : query.AsQueryable();
        }
        else
        {
            _resetSet = predicate != null
                ? _dataContext.Set<T>().Where(predicate).AsQueryable()
                : _dataContext.Set<T>().AsQueryable();
        }

        _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
        //total = _resetSet.Count();
        return _resetSet.AsQueryable();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> where)
    {
        return  await _dbSet.CountAsync(where);
    }

    public async Task<bool> CheckContainsAsync(Expression<Func<T, bool>> predicate)
    {
        return _dataContext.Set<T>().Count(predicate) > 0;
    }
}