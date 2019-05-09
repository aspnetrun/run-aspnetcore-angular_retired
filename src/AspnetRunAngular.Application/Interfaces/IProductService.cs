using AspnetRunAngular.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunAngular.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductList();
        Task<ProductModel> GetProductById(int productId);
        Task<IEnumerable<ProductModel>> GetProductsByName(string name);
        Task<IEnumerable<ProductModel>> GetProductsByCategoryId(int categoryId);
        Task<ProductModel> Create(ProductModel product);
        Task Update(ProductModel product);
        Task Delete(ProductModel product);
    }
}
