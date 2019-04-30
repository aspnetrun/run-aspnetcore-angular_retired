using AspnetRunAngular.Core.Entities.Base;
using AspnetRunAngular.Core.Repositories.Base;
using AspnetRunAngular.Infrastructure.Data;

namespace AspnetRunAngular.Infrastructure.Repository.Base
{
    public class EnumRepository<T> : RepositoryBase<T, int>, IEnumRepository<T>
    where T : class, IEntityBase<int>
    {
        public EnumRepository(AspnetRunContext context)
            : base(context)
        {
        }
    }
}
