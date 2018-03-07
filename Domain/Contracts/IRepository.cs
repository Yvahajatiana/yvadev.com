namespace Yvadev.Domain.Contracts
{
    using System.Collections.Generic;
    using Yvadev.Domain.Entities;

    public interface IRepository<T> where T : BaseEntity
    {
        T Get(long Id);

        void Add(T Entity);

        List<T> GetAll();

        void Update(T Entity);

        void Delete(T Entity);

        void SaveChange(T Entity);
    }
}
