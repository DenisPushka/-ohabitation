using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Сohabitation
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(c => { c.EnableEndpointRouting = false; });
            // services.AddSingleton<ApplicationContext, ApplicationContext>();
            services.AddSingleton<ApplicationContextSQL, ApplicationContextSQL>();
            services.AddSingleton<ICohabitationRepository, CohabitationRepository>();
            services.AddMvcCore();
            services.AddMvc();
        }

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
                        "api/{controller}/{action}/{id?}"
                    );

                    b.MapRoute(
                        "default",
                        "{controller}/{action}/{id?}",
                        new { contrller = "Root", action = "Index" }
                    );
                }
            );    
        }
    }
}
