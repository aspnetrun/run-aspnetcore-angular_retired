using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRunAngular.Application.Interfaces;
using AspnetRunAngular.Application.Mapper;
using AspnetRunAngular.Application.Models;
using AspnetRunAngular.Core.Entities;
using AspnetRunAngular.Core.Interfaces;
using AspnetRunAngular.Core.Repositories.Base;

namespace AspnetRunAngular.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IAppLogger<CategoryService> _logger;

        public CategoryService(IRepository<Category> categoryRepository, IAppLogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            var categoryList = await _categoryRepository.ListAllAsync();

            var categoryModels = ObjectMapper.Mapper.Map<IEnumerable<CategoryModel>>(categoryList);

            return categoryModels;
        }
    }
}
