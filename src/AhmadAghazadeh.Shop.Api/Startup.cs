using System;
using AhmadAghazadeh.Framework.AssemblyHelper;
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.DependencyInjection;
using AhmadAghazadeh.Shop.Persistence;
using AhmadAghazadeh.Shop.ReadModel.Database.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace AhmadAghazadeh.Shop.Api
{
    public class Startup
    {

        private readonly IWebHostEnvironment env;
        private readonly IConfiguration configuration;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            this.env = env;
            this.configuration = configuration;
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblyHelper = new AssemblyDiscovery("AhmadAghazadeh*.dll");
           

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            var build = builder.Build();
            var connectionString = build.GetConnectionString("DefaultConnection");

            Registrar(services, env, assemblyHelper);
            services.AddControllers();
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shop Service", Version = "v1" });
            });
            
            services.AddDbContext<IDbContext, ShopDbContext>((provider, options) =>
            {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();

            });

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var dbContext = serviceProvider.GetRequiredService<IDbContext>();
                if (env.IsDevelopment() == false)
                    dbContext.Migrate();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void Registrar(IServiceCollection services, IWebHostEnvironment env, AssemblyDiscovery assemblyHelper)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            var build = builder.Build();
            var connectionString = build.GetConnectionString("DefaultConnection");

            var registrars = assemblyHelper.DiscoverInstances<IRegistrar>("AhmadAghazadeh");
            foreach (IRegistrar registrar in registrars)
            {
                registrar.Register(services, assemblyHelper);
            }

            services.AddDbContext<ShopContext>(op =>
            {
                op.UseSqlServer(connectionString);
                op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

           
        }

    }
}
