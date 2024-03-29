﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Lib.Repositories.Abstractions;
using MusicStore.Products.Core.Products;

namespace MusicStore.Products.Application.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByIdAsync( int id );
        Task<List<Product>> GetByIdsAsync( List<int> ids );
    }
}
