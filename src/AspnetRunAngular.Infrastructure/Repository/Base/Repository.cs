using AspnetRunAngular.Core.Entities.Base;
using AspnetRunAngular.Core.Repositories.Base;
using AspnetRunAngular.Infrastructure.Data;
using System;

namespace AspnetRunAngular.Infrastructure.Repository.Base
{
    public class Repository<T> : RepositoryBase<T, Guid>, IRepository<T>
       where T : class, IEntityBase<Guid>
    {
        public Repository(AspnetRunContext context)
            : base(context)
        {
        }
    }
}
