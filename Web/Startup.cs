using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yvadev.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Yvadev.Domain.Contracts;
using Yvadev.Infrastructure.EF.Repositories;
using Microsoft.AspNetCore.Identity;
using Yvadev.Infrastructure.EF.Models;

namespace Yvadev.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ApplicationContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Yvadev.Infrastructure.EF")));
            services.AddDbContext<IdentityContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Yvadev.Infrastructure.EF")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
        }
    }
}
