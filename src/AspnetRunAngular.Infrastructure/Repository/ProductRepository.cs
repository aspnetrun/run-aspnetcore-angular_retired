using AspnetRunAngular.Core.Entities;
using AspnetRunAngular.Core.Repositories;
using AspnetRunAngular.Infrastructure.Data;
using AspnetRunAngular.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunAngular.Infrastructure.Repository
{
    //TODO: Dynamicly include children entities in GetByIdAsync and ListAllAsync (i.e. Product.Category and Product.Status)
    // Check specification pattern
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AspnetRunContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await Table.Include(p => p.Category).Include(p => p.Status).Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string productName)
        {
            return await Table.Include(p => p.Category).Include(p => p.Status).Where(p => p.Name == productName).ToListAsync();
        }
    }
}
