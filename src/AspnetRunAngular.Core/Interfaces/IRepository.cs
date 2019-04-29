using AspnetRunAngular.Core.Entities.Base;
using System;

namespace AspnetRunAngular.Core.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T, Guid> where T : IEntityBase<Guid>
    {
    }
}
