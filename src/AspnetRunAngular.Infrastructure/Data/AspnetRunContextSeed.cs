using AspnetRunAngular.Core.Entities;
using AspnetRunAngular.Core.Repositories;
using AspnetRunAngular.Core.Repositories.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunAngular.Infrastructure.Data
{
    public class AspnetRunContextSeed
    {
        private readonly AspnetRunContext _aspnetRunContext;
        private readonly IProductRepository _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IEnumRepository<ProductStatus> _productStatusRepository;

        public AspnetRunContextSeed(
            AspnetRunContext aspnetRunContext,
            IProductRepository productRepository,
            IRepository<Category> categoryRepository,
            IEnumRepository<ProductStatus> productStatusRepository)
        {
            _aspnetRunContext = aspnetRunContext;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productStatusRepository = productStatusRepository;
        }

        public async Task SeedAsync()
        {
            // TODO: Only run this if using a real database
            // _aspnetRunContext.Database.Migrate();
            // _aspnetRunContext.Database.EnsureCreated();

            await SeedCategoriesAsync();
            await SeedProductStatusesAsync();
            await SeedProductsAsync();
        }

        private async Task SeedCategoriesAsync()
        {
            if (!_categoryRepository.Table.Any())
            {
                var categories = new List<Category>
                {
                    new Category{Name="TV", Description = "TV"},
                    new Category{Name="Phone", Description = "Phone"}
                };

                await _categoryRepository.AddRangeAsync(categories);
            }
        }

        private async Task SeedProductStatusesAsync()
        {
            if (!_productStatusRepository.Table.Any())
            {
                await _productStatusRepository.AddRangeAsync(GetPredefinedProductStatuses());
            }
        }

        private IEnumerable<ProductStatus> GetPredefinedProductStatuses()
        {
            return new List<ProductStatus>()
            {
                ProductStatus.Sellable,
                ProductStatus.Damaged,
                ProductStatus.Lost
            };
        }

        private async Task SeedProductsAsync()
        {
            if (!_productRepository.Table.Any())
            {
                var categoryTV = _categoryRepository.Table.First(c => c.Name == "TV");
                var categoryPhone = _categoryRepository.Table.First(c => c.Name == "Phone");

                var products = new List<Product>
                {
                    new Product{ Name = "IPhone X", Description = "IPhone X", UnitPrice = 19.5M, Category = categoryPhone, StatusId = 1 },
                    new Product{ Name = "Samsung S10", Description = "Samsung S10", UnitPrice = 33.5M, Category = categoryPhone, StatusId = 2 },
                    new Product{ Name = "LG TV", Description = "LG TV", UnitPrice = 33.5M, Category = categoryTV, StatusId = 3 }
                };

                await _productRepository.AddRangeAsync(products);
            }
        }
    }
}
