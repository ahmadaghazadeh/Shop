using System;
using System.Linq;
using AhmadAghazadeh.Framework.AssemblyHelper;
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.DependencyInjection;
using AhmadAghazadeh.Shop.Persistence;
using AhmadAghazadeh.Shop.ReadModel.Database.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            var assemblyHelper = new AssemblyHelper(nameof(AhmadAghazadeh));
            services.AddControllers();

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            var build = builder.Build();
            var connectionString = build.GetConnectionString("DefaultConnection");

            services.AddMvc();

            Registrar(services, env, assemblyHelper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TKD Service", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.MapType(typeof(IFormFile), () => new OpenApiSchema() { Type = "file", Format = "binary" });
            });
            services.AddDbContext<ShopDbContext>(op =>
            {
                op.UseSqlServer(connectionString);
                op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<IDbContext>();
            if (env.IsDevelopment() == false)
                dbContext.Migrate();
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void Registrar(IServiceCollection services, IWebHostEnvironment env, AssemblyHelper assemblyHelper)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            var build = builder.Build();
            var connectionString = build.GetConnectionString("DefaultConnection");

            var registrars = assemblyHelper.GetInstanceByInterface(typeof(IRegistrar));
            foreach (IRegistrar registrar in registrars)
            {
                registrar.Register(services, connectionString);
            }

            services.AddDbContext<ShopContext>(op =>
            {
                op.UseSqlServer(connectionString);
                op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

           
        }

    }
}
