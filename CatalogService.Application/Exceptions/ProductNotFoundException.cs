﻿using CatalogService.Application.Exceptions.Abstract;

namespace CatalogService.Domain.Exceptions
{
    public sealed class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id) : base($"The product with id:{id} could not found.")
        {
        }
    }
}
