using AspnetRunAngular.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunAngular.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategoryList();
    }
}
