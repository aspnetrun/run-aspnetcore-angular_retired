using AspnetRunAngular.Core.Entities;
using AspnetRunAngular.Core.Repositories;
using AspnetRunAngular.Infrastructure.Data;
using AspnetRunAngular.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunAngular.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AspnetRunContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(Guid categoryId)
        {
            return await Table.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string productName)
        {
            return await Table.Where(p => p.Name == productName).ToListAsync();
        }
    }
}
