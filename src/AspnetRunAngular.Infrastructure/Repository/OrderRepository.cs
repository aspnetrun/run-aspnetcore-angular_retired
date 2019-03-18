using AspnetRunAngular.Core.Entities;
using AspnetRunAngular.Core.Interfaces;
using AspnetRunAngular.Infrastructure.Data;
using System.Threading.Tasks;

namespace AspnetRunAngular.Infrastructure.Repository
{
    public class OrderRepository : AspnetRunRepository, IOrderRepository
    {
        public OrderRepository(AspnetRunContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<Order> SaveOrder(Order order)
        {
            return await SaveAsync(order);
        }
    }
}
