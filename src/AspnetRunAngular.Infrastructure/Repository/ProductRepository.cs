using AspnetRunAngular.Core.Entities;
using AspnetRunAngular.Core.Repositories;
using AspnetRunAngular.Core.Specifications;
using AspnetRunAngular.Infrastructure.Data;
using AspnetRunAngular.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspnetRunAngular.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AspnetRunContext context)
            : base(context)
        {
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            //TODO: should be refactored
            var products = await GetAsync(p => p.Id == id, null, new List<Expression<Func<Product, object>>> { p => p.Category });
            return products.FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            var spec = new ProductWithCategorySpecification(categoryId);
            return await GetAsync(spec);
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string productName)
        {
            var spec = new ProductWithCategorySpecification(productName);
            return await GetAsync(spec);
        }
    }
}
