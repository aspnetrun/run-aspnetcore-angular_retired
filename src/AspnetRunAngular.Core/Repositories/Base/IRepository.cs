using AspnetRunAngular.Core.Entities.Base;
using System;

namespace AspnetRunAngular.Core.Repositories.Base
{
    public interface IRepository<T> : IRepositoryBase<T, Guid> where T : IEntityBase<Guid>
    {
    }
}
