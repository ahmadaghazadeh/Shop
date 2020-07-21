using AhmadAghazadeh.Framework.AssemblyHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using AhmadAghazadeh.Framework.DependencyInjection;
using AhmadAghazadeh.Shop.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Shop
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;

        public Startup(IWebHostEnvironment env )
        {
            this.env = env;
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var assemblyHelper = new AssemblyHelper(nameof(AhmadAghazadeh));
            Registrar(services, env, assemblyHelper);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddMvc();

        }

        private void Registrar(IServiceCollection services, IWebHostEnvironment env, AssemblyHelper assemblyHelper)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var registrars = assemblyHelper.GetInstanceByInterface(typeof(IRegistrar));
            foreach (IRegistrar registrar in registrars)
            {
                registrar.Register(services, connectionString);
            }

            services.AddDbContext<ShopDbContext>(op =>
            {
                op.UseSqlServer(connectionString);
                op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
