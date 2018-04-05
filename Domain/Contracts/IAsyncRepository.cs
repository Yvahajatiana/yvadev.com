namespace Yvadev.Domain.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Yvadev.Domain.Entities;

    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> Get(long Id);

        Task AddAsync(T Entity);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);

        Task UpdateAsync(T Entity);

        Task DeleteAsync(T Entity);
    }
}
