using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AhmadAghazadeh.Shop.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace Shop
{
    public class ShopDbFactory : IDesignTimeDbContextFactory<ShopDbContext>
    {
        public ShopDbContext CreateDbContext(string[] args)
        {

            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{envName}.json", true, true);
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ShopDbContext(optionsBuilder.Options);
        }
    }
}
