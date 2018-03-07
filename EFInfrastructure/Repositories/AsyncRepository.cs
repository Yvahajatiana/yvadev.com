namespace Yvadev.Infrastructure.EF.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Yvadev.Domain.Contracts;
    using Yvadev.Domain.Entities;
    using Yvadev.Infrastructure.EF.Contexts;

    public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;

        public AsyncRepository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<T> Get(long Id)
        {
            return await entities.SingleOrDefaultAsync(x => x.Id == Id);
        }

        public async Task AddAsync(T Entity)
        {
            if (Entity == null) new ArgumentNullException("Entity");
            await entities.AddAsync(Entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T Entity)
        {
            if (Entity == null) new ArgumentNullException("Entity");
            entities.Remove(Entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task UpdateAsync(T Entity)
        {
            if (Entity == null) new ArgumentNullException("Entity");
            await context.SaveChangesAsync();
        }
    }
}
