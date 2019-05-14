using AspnetRunAngular.Core.Entities.Base;
using AspnetRunAngular.Core.Repositories.Base;
using AspnetRunAngular.Infrastructure.Data;

namespace AspnetRunAngular.Infrastructure.Repository.Base
{
    public class Repository<T> : RepositoryBase<T, int>, IRepository<T>
        where T : class, IEntityBase<int>
    {
        public Repository(AspnetRunContext context)
            : base(context)
        {
        }
    }
}
