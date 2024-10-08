﻿using AutoMapper;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories;

public class VariantValueRepository : RepositoryBase<VariantValue>, IVariantValueRepository
{
    public VariantValueRepository(IDbFactory dbFactory,IMapper mapper) : base(dbFactory,mapper)
    {

    }
}