namespace Yvadev.Infrastructure.EF.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Yvadev.Domain.Contracts;
    using Yvadev.Domain.Entities;
    using Yvadev.Infrastructure.EF.Contexts;

    public class Repository<T> : IRepository<T>  where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> entities;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public T Get(long Id)
        {
            return entities.SingleOrDefault(x => x.Id == Id);
        }

        public void Add(T Entity)
        {
            if (Entity == null) new ArgumentNullException("Entity");
            entities.Add(Entity);
            context.SaveChanges();
        }

        public void Delete(T Entity)
        {
            if (Entity == null) new ArgumentNullException("Entity");
            entities.Remove(Entity);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public void Update(T Entity)
        {
            if (Entity == null) new ArgumentNullException("Entity");
            context.SaveChanges();
        }

        public void SaveChange(T Entity)
        {
            context.SaveChanges();
        }
    }
}
