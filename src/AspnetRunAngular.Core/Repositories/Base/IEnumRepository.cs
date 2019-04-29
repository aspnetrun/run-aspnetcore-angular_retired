using AspnetRunAngular.Core.Entities.Base;

namespace AspnetRunAngular.Core.Repositories.Base
{
    public interface IEnumRepository<T> : IRepositoryBase<T, int> where T : IEntityBase<int>
    {
    }
}
