
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.Core.Security;
using AhmadAghazadeh.Framework.DependencyInjection;
using AhmadAghazadeh.Framework.Security;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Services.Customers;
using AhmadAghazadeh.Shop.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AhmadAghazadeh.Shop.CustomerContext.Configuration
{
    public class Registrar  : RegistrarBase<Registrar>
    {
        public override void Register(IServiceCollection services)
        {
         
            services.AddTransient<INationalCodeDuplicationChecker, NationalCodeDuplicationChecker>();
        }

        public override void RegisterPersistence(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IDbContext, ShopDbContext>((provider, options) =>
            {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();

            });
        }
    }
}
