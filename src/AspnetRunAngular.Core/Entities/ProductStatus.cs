using AspnetRunAngular.Core.Entities.Base;

namespace AspnetRunAngular.Core.Entities
{
    public class ProductStatus : Enumeration
    {
        public static ProductStatus Sellable = new ProductStatus(1, "Sellable", "Sellable");
        public static ProductStatus Damaged = new ProductStatus(2, "Damaged", "Damaged");
        public static ProductStatus Lost = new ProductStatus(3, "Lost", "Lost");

        protected ProductStatus()
        {
        }

        public ProductStatus(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}
