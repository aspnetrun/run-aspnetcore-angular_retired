using AspnetRunAngular.Core.Entities.Base;

namespace AspnetRunAngular.Core.Interfaces
{
    public interface IEnumRepository<T> : IRepositoryBase<T, int> where T : IEntityBase<int>
    {
    }
}
