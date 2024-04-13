﻿using AutoMapper;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories;

public class AttributeValueRepository : RepositoryBase<VariantValue>, IAttributeValueRepository
{
    public AttributeValueRepository(IDbFactory dbFactory,IMapper mapper,int userId) : base(dbFactory,mapper, userId)
    {
    }
}