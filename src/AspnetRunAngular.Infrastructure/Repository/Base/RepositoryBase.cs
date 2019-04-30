using AspnetRunAngular.Core.Entities.Base;
using AspnetRunAngular.Core.Repositories.Base;
using AspnetRunAngular.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunAngular.Infrastructure.Repository.Base
{
    public class RepositoryBase<T, TId> : IRepositoryBase<T, TId> where T : class, IEntityBase<TId>
    {
        public RepositoryBase(AspnetRunContext context)
        {
            _context = context;
        }

        private readonly DbContext _context;

        private DbSet<T> _entities;

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();

                return _entities;
            }
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            Entities.AddRange(entities);
            await _context.SaveChangesAsync();

            return entities;
        }

        public async Task<T> SaveAsync(T entity)
        {
            if (entity.Id == null || entity.Id.Equals(default(TId)))
            {
                Entities.Add(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            Entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public IQueryable<T> Table => Entities;

        public IQueryable<T> TableNoTracking => Entities.AsNoTracking();
    }
}
