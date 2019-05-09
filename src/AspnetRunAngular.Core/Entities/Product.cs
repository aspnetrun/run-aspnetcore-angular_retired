using AspnetRunAngular.Core.Entities.Base;

namespace AspnetRunAngular.Core.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int StatusId { get; set; }
        public ProductStatus Status { get; set; }
    }
}
