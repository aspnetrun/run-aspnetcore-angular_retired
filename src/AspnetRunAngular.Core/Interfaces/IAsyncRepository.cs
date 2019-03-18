using AspnetRunAngular.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunAngular.Core.Interfaces
{
    public interface IAsyncRepository
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : Entity;
        Task<IReadOnlyList<T>> ListAllAsync<T>() where T : Entity;
        Task<T> AddAsync<T>(T entity) where T : Entity;
        Task UpdateAsync<T>(T entity) where T : Entity;
        Task<T> SaveAsync<T>(T entity) where T : Entity;
        Task DeleteAsync<T>(T entity) where T : Entity;
        Task<long> GetNextNumberAsync(string sequenceName);
    }
}
