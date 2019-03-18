using System;

namespace AspnetRunAngular.Core.Entities
{
    public class OrderItem : Entity
    {
        public Order Order { get; set; }
        public Guid OrderId { get; set; }

        public Product Product { get; set; }
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
