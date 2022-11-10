using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Сohabitation
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
            services.AddControllersWithViews(c => { c.EnableEndpointRouting = false; });
            // services.AddSingleton<ApplicationContext, ApplicationContext>();
            services.AddSingleton<ApplicationContextSQL, ApplicationContextSQL>();
            services.AddTransient<ICohabitationRepository, CohabitationRepository>();
            services.AddMvcCore();
            services.AddMvc();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseMvc(b =>
            {
                b.MapRoute(
                    "api",
                    "api/{controller}/{action}/{id?}");

                b.MapRoute(
                    "default",
                    "{controller}/{action}/{id?}",
                    new { contrller = "Root", action = "Index" });
            });
                
        }
    }
}
