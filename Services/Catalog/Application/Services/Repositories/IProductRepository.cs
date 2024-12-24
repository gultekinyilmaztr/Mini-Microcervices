﻿using Base.Persistence.Repositories;
using Domain.Entites;

namespace Application.Services.Repositories
{
    public interface IProductRepository : IAsyncRepository<Product, Guid>
    {
    }
}
