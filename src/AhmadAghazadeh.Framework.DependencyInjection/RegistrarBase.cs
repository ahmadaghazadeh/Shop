using System.Linq;
using AhmadAghazadeh.Framework.Application;
using AhmadAghazadeh.Framework.Core.Application;
using AhmadAghazadeh.Framework.Core.DependencyInjection;
using AhmadAghazadeh.Framework.Core.EventBus;
using AhmadAghazadeh.Framework.Core.Facade;
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.Core.Security;
using AhmadAghazadeh.Framework.Persistence;
using AhmadAghazadeh.Framework.Security;
using Microsoft.Extensions.DependencyInjection;

namespace AhmadAghazadeh.Framework.DependencyInjection
{
    public abstract class  RegistrarBase<TRegister> : IRegistrar
    {
        private readonly AssemblyHelper.AssemblyHelper assemblyHelper;

        protected RegistrarBase()
        {
            var nameSpaceSpell = typeof(TRegister).Namespace?.Split('.');
            var schemaName = nameSpaceSpell?[0] + "." + nameSpaceSpell?[1]+ "." + nameSpaceSpell?[2];
            assemblyHelper = new AssemblyHelper.AssemblyHelper(schemaName);
        }

        public virtual void Register(IServiceCollection services)
        {

        }

        public virtual void RegisterPersistence(IServiceCollection services, string connectionString)
        {
           
        }
         

        public void Register(IServiceCollection services, string connectionString)
        {
            RegisterPersistence(services,connectionString);
            RegisterCommandHandlers(services);
            RegisterMapper(services);
            RegisterRepository(services);
            Register(services);
            RegisterFramework(services);
            RegisterCommandFacade(services);
            RegisterQueryFacade(services);
        }

        private void RegisterQueryFacade(IServiceCollection services)
        {
            var repositories = assemblyHelper.GetClassByInterface(typeof(IQueryFacade));
            foreach (var repository in repositories)
            {
                var baseInterfaces = repository.GetInterfaces().Where(a => a.IsGenericType == false);
                foreach (var baseInterface in baseInterfaces)
                {
                    services.AddTransient(baseInterface, repository);
                }
            }
        }

        private void RegisterCommandFacade(IServiceCollection services)
        {
            var repositories = assemblyHelper.GetClassByInterface(typeof(ICommandFacade));
            foreach (var repository in repositories)
            {
                var baseInterfaces = repository.GetInterfaces().Where(a => a.IsGenericType == false);
                foreach (var baseInterface in baseInterfaces)
                {
                    services.AddTransient(baseInterface, repository);
                }
            }
        }

        private void RegisterFramework(IServiceCollection services)
        {
            services.AddSingleton<IHashProvider, HashProvider>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDiContainer, DiContainer>();
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IEventBus, EventBus.EventBus>();
        }

        private void RegisterRepository(IServiceCollection services)
        {
            var commandHandlers = assemblyHelper.GetClassByInterface(typeof(IRepository<>));
            foreach (var commandHandler in commandHandlers)
            {
                var baseInterface = commandHandler.GetInterfaces()[0];
                services.AddScoped(baseInterface, commandHandler);
            }
        }

        private void RegisterMapper(IServiceCollection services)
        {
            var commandHandlers = assemblyHelper.GetClassByInterface(typeof(IEntityMapping));
            foreach (var commandHandler in commandHandlers)
            {
                var baseInterface = commandHandler.GetInterfaces()[0];
                services.AddTransient(baseInterface, commandHandler);
            }
        }


        private void RegisterCommandHandlers(IServiceCollection services)
        {
            var commandHandlers = assemblyHelper.GetClassByInterface(typeof(ICommandHandler<>));
            foreach (var commandHandler in commandHandlers)
            {
                var baseInterface = commandHandler.GetInterfaces()[0];
                services.AddScoped(baseInterface, commandHandler);
            }
        }
    }
}