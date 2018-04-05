namespace Yvadev.Domain.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Yvadev.Domain.Entities;

    public interface IRepository<T> where T : BaseEntity
    {
        T Get(long Id);

        void Add(T Entity);

        List<T> GetAll();

        List<T> GetAll(Expression<Func<T, bool>> predicate);

        void Update(T Entity);

        void Delete(T Entity);

        void SaveChange(T Entity);
    }
}
