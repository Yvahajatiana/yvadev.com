using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Yvadev.DependencyResolution;
using Yvadev.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DomainTest
{
    public class StartupTest
    {
        public StartupTest(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase(Configuration.GetConnectionString("DefaultConnection")));
            IocResolver.Register(services);
        }
    }
}
