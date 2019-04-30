using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunAngular.Application.Interfaces;
using AspnetRunAngular.Application.Mapper;
using AspnetRunAngular.Application.Models;
using AspnetRunAngular.Core.Interfaces;
using AspnetRunAngular.Core.Repositories;

namespace AspnetRunAngular.Application.Services
{
    class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, IAppLogger<ProductService> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductModel>> GetProductList()
        {
            var productList = await _productRepository.ListAllAsync();

            var productModels = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);

            return productModels;
        }

        public async Task<ProductModel> GetProductById(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> GetProductByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModel> Create(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
