using AspnetRunAngular.Core.Entities.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunAngular.Core.Repositories.Base
{
    public interface IRepositoryBase<T, TId> where T : IEntityBase<TId>
    {
        IQueryable<T> Table { get; }

        IQueryable<T> TableNoTracking { get; }

        Task<T> GetByIdAsync(TId id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task<T> SaveAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
