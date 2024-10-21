﻿using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.MemberShipType.Queries.MongoDBQueries.GetAllCategories
{
    public sealed record GetAllAttributeQuery() : IQuery<IEnumerable<AttributeResponseDto>>;
}
