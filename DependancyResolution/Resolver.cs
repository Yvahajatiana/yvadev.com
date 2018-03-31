namespace Yvadev.DependencyResolution
{
    using Microsoft.Extensions.DependencyInjection;
    using Yvadev.Domain.Contracts;
    using Yvadev.Domain.Services;
    using Yvadev.Infrastructure.EF.Repositories;

    public static class Resolver
    {
        public static void Register(IServiceCollection services)
        {
            /*
             * Dependancy Injection
             */
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
