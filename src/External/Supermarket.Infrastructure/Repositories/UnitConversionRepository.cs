﻿using AutoMapper;
using Supermarket.Infrastructure.DbFactories;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Infrastructure.Repositories
{
    public class UnitConversionRepository: RepositoryBase<UnitConversion>,IUnitConversionRepository
    {
        public UnitConversionRepository(IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper) { }
    }
}
