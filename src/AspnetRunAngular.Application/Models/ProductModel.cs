using AspnetRunAngular.Application.Models.Base;

namespace AspnetRunAngular.Application.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public CategoryModel Category { get; set; }
        public ProductStatusModel Status { get; set; }
    }
}
