using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.Common;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories
{
    public class RepositoryBaseBasic<T> : IBasicRepository<T> where T : BaseDomainBasic
    {
        private SuperMarketDbContext _dataContext;
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

        public async Task<T> UpdateAsync(T entity, int id)
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
            _dbSet.Update(entityUpdate);
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entityDelete = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entityDelete == null)
            {
                return null;
            }
            _dbSet.Remove(entityDelete);
            return entityDelete;
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
