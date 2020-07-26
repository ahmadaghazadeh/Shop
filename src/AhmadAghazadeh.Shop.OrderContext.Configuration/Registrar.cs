using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.DependencyInjection;
using AhmadAghazadeh.Shop.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AhmadAghazadeh.Shop.OrderContext.Configuration
{
    public class Registrar : RegistrarBase<Registrar>
    {

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
