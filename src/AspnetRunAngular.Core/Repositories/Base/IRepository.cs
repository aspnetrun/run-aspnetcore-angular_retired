using AspnetRunAngular.Core.Entities.Base;

namespace AspnetRunAngular.Core.Repositories.Base
{
    public interface IRepository<T> : IRepositoryBase<T, int> where T : IEntityBase<int>
    {
    }
}
