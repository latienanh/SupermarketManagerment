﻿using AutoMapper;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper) { }
    }
}
