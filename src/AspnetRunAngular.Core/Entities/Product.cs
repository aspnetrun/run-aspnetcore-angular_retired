using AspnetRunAngular.Core.Entities.Base;
using System;

namespace AspnetRunAngular.Core.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int StatusId { get; set; }
        public ProductStatus Status { get; set; }
    }
}
