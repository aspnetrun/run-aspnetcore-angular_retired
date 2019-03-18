using System;
using System.Collections.Generic;

namespace AspnetRunAngular.Core.Entities
{
    public class Order : Entity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public string Code { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<OrderItem> OrderItems { get; private set; }
    }
}
