using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SingleWebMvcCrud.Services;

namespace SingleWebMvcCrud
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<ITodosData, InMemoryTodosData>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("default",
                    "/{controller}/{action}/{id?}",
                    new { controller = "Home", action = "Index" });
            });
        }
    }
}
