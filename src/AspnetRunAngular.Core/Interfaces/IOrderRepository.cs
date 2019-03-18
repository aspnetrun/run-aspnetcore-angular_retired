using AspnetRunAngular.Core.Entities;
using System.Threading.Tasks;

namespace AspnetRunAngular.Core.Interfaces
{
    public interface IOrderRepository : IAsyncRepository
    {
        Task<Order> SaveOrder(Order order);
    }
}
