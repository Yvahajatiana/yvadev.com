
namespace Yvadev.Infrastructure.EF.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Yvadev.Domain.Entities;
    using Yvadev.Infrastructure.EF.Maps;

    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new PostMap(modelBuilder.Entity<Post>());
            new CategoryMap(modelBuilder.Entity<Category>());
            new SEOMap(modelBuilder.Entity<SEO>());
        }
    }
}
