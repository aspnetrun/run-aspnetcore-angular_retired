using AspnetRunAngular.Core.Entities;
using AspnetRunAngular.Core.Interfaces;
using AspnetRunAngular.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunAngular.Infrastructure.Repository
{
    public class AspnetRunRepository : IAsyncRepository
    {
        protected readonly AspnetRunContext _dbContext;

        public AspnetRunRepository(AspnetRunContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync<T>(Guid id) where T : Entity
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync<T>() where T : Entity
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync<T>(T entity) where T : Entity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> SaveAsync<T>(T entity) where T : Entity
        {
            if (entity.Id == null || entity.Id == Guid.Empty)
            {
                return await AddAsync(entity);
            }
            else
            {
                await UpdateAsync(entity);
            }

            return entity;
        }

        public async Task DeleteAsync<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<long> GetNextNumberAsync(string sequenceName)
        {
            //TODO: will be implemented
            return 0;
            //var dbConnection = _dbContext.Database.GetDbConnection();

            //using (var connection = new SqlConnection(dbConnection.ConnectionString))
            //{
            //    connection.Open();

            //    var result = await connection.QueryAsync<long>("SELECT NEXT VALUE FOR " + sequenceName);

            //    return result.First();
            //}
        }
    }
}
