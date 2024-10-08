﻿using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Primitives;
using Supermarket.Infrastructure.DbContext;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories
{
    public class RepositoryBaseBasic<T> : IBasicRepository<T> where T : EntityBasic
    {
        private SuperMarketDbContext? _dataContext;
        private IDbFactory _dbFactory;
        protected DbSet<T> _dbSet;

        protected SuperMarketDbContext _dbContext => _dataContext ?? (_dataContext =_dbFactory.Init());
        public RepositoryBaseBasic(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity) 
        {
            if (entity == null)
            {
                return null;
            }
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity, Guid id)
        {
            var entityUpdate = await _dbSet.FirstOrDefaultAsync(x => x.Id==id);
            if (entityUpdate == null)
            {
                return null;
            }
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                property.SetValue(entityUpdate,property.GetValue(entity));
            }
            entityUpdate.Id = id;
            _dbSet.Update(entityUpdate);
            return entity;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            var entityDelete = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entityDelete == null)
            {
                return null;
            }
            _dbSet.Remove(entityDelete);
            return entityDelete;
        }

      

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
