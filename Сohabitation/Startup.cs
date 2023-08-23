using System.Configuration;
using DataAccess;
using DataAccess.Interface;
using DataAccess.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Сohabitation
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddTransient<ApplicationContextSql>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddMvcCore();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        "default",
                        "api/{controller}/action");
                    endpoints.MapControllers();
                }
            );
        }
    }
}