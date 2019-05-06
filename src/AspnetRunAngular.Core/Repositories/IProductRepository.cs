using AspnetRunAngular.Core.Entities;
using AspnetRunAngular.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunAngular.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductByNameAsync(string productName);
        Task<IEnumerable<Product>> GetProductByCategoryIdAsync(Guid categoryId);
    }
}
