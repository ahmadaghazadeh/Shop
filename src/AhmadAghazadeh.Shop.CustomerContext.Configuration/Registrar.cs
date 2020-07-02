using AhmadAghazadeh.Framework.Application;
using AhmadAghazadeh.Framework.Core.Security;
using AhmadAghazadeh.Framework.DependencyInjection;
using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Framework.Security;
using AhmadAghazadeh.Shop.CustomerContext.Application.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Services;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AhmadAghazadeh.Shop.CustomerContext.Configuration
{
    public class Registrar : IRegistrar
    {
        public void Register(WindsorContainer container)
        {
            container.Register(Component.For<IHashProvider>()
                               .ImplementedBy<HashProvider>()
                               .LifestyleSingleton());

            container.Register(Classes.FromAssemblyContaining<SignUpCommandHandler>()
                               .BasedOn(typeof(ICommandHandler<>))
                               .WithServiceAllInterfaces()
                               .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<INationalCodeDuplicationChecker>()
                              .BasedOn(typeof(IDomainService))
                              .WithServiceAllInterfaces()
                              .LifestyleTransient());

        }
    }
}
