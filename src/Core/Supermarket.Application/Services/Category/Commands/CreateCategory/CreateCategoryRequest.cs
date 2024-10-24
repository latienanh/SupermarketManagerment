﻿using Microsoft.AspNetCore.Http;

namespace Supermarket.Application.Services.Category.Commands.CreateCategory
{
    public sealed record CreateCategoryRequest
    {
        public Guid? ParentId { get; set; }
        public string? Name { get; set; }
        public string? Describe { get; set; }
        public IFormFile? Image { get; set; }
        public string? PathImage { get; set; }
    }
}
