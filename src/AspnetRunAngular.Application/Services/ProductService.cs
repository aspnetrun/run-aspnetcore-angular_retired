using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunAngular.Application.Interfaces;
using AspnetRunAngular.Application.Mapper;
using AspnetRunAngular.Application.Models;
using AspnetRunAngular.Core.Entities;
using AspnetRunAngular.Core.Interfaces;
using AspnetRunAngular.Core.Repositories;

namespace AspnetRunAngular.Application.Services
{
    public class ProductService : IProductService
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

        public async Task<ProductModel> GetProductById(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            var productModel = ObjectMapper.Mapper.Map<ProductModel>(product);

            return productModel;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsByName(string name)
        {
            var productList = await _productRepository.GetProductsByNameAsync(name);

            var productModels = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);

            return productModels;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsByCategoryId(int categoryId)
        {
            var productList = await _productRepository.GetProductsByCategoryIdAsync(categoryId);

            var productModels = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);

            return productModels;
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.Id);
            if (existingProduct != null)
            {
                throw new ApplicationException("Product with this id already exists");
            }

            var newProduct = ObjectMapper.Mapper.Map<Product>(product);
            newProduct = await _productRepository.SaveAsync(newProduct);

            _logger.LogInformation("Entity successfully added - AspnetRunAppService");

            var newProductModel = ObjectMapper.Mapper.Map<ProductModel>(newProduct);
            return newProductModel;
        }

        public async Task UpdateProduct(ProductModel product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.Id);
            if (existingProduct == null)
            {
                throw new ApplicationException("Product with this id is not exists");
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.UnitPrice = product.UnitPrice;
            existingProduct.CategoryId = product.CategoryId;

            await _productRepository.SaveAsync(existingProduct);

            _logger.LogInformation("Entity successfully updated - AspnetRunAppService");
        }

        public async Task DeleteProductById(int productId)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productId);
            if (existingProduct == null)
            {
                throw new ApplicationException("Product with this id is not exists");
            }

            await _productRepository.DeleteAsync(existingProduct);

            _logger.LogInformation("Entity successfully deleted - AspnetRunAppService");
        }
    }
}
