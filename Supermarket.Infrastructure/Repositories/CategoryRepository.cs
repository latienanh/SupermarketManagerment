using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories;

public class CategoryRepository : RepositoryBase<Category>,ICategoryRepository
{
    public CategoryRepository(IDbFactory dbFactory, IMapper mapper,int userId):base(dbFactory,mapper,userId)
    {
        
    }

}