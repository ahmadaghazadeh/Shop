using System.Linq;
using AhmadAghazadeh.Framework.Application;
using AhmadAghazadeh.Framework.AssemblyHelper;
using AhmadAghazadeh.Framework.Core.Application;
using AhmadAghazadeh.Framework.Core.AssemblyHelper;
using AhmadAghazadeh.Framework.Core.DependencyInjection;
using AhmadAghazadeh.Framework.Core.Domain;
using AhmadAghazadeh.Framework.Core.EventBus;
using AhmadAghazadeh.Framework.Core.Facade;
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.Core.Security;
using AhmadAghazadeh.Framework.EventBus;
using AhmadAghazadeh.Framework.Persistence;
using AhmadAghazadeh.Framework.Security;
using Microsoft.Extensions.DependencyInjection;

namespace AhmadAghazadeh.Framework.DependencyInjection
{
    public abstract class RegistrarBase<TRegister> : IRegistrar
    {
        private IServiceCollection _serviceCollection;
        private IAssemblyDiscovery _assemblyDiscovery;
        private readonly string _namespace;
        private readonly string _namespacePart1;
        protected RegistrarBase()
        {
            var nameSpaceSpell = typeof(TRegister).Namespace?.Split('.');
            _namespace  = string.Join(".", nameSpaceSpell.Take(3));
            _namespacePart1 = nameSpaceSpell?[0]; 
        }

        public void Register(IServiceCollection serviceCollection, IAssemblyDiscovery assemblyDiscovery)
        {
            _assemblyDiscovery = assemblyDiscovery;
            _serviceCollection = serviceCollection;
            RegisterFramework();
            RegisterTransient<IDomainService>();
            RegisterTransient<IEntityMapping>();
            RegisterTransient<IRepository>();
            RegisterTransient<IHandler>();
            RegisterTransient<ICommandFacade>();

        }
        private void RegisterFramework()
        {
            _serviceCollection.AddScoped<IAssemblyDiscovery, AssemblyDiscovery>(a => new AssemblyDiscovery(_namespacePart1+"*.dll"));
            _serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            _serviceCollection.AddScoped<IDiContainer, DiContainer>();
            _serviceCollection.AddScoped<ICommandBus, CommandBus>();
            _serviceCollection.AddScoped<IEventBus, InMemoryEventBus>();
            _serviceCollection.AddScoped<IHashProvider, HashProvider>();
        }

        private void RegisterTransient<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach (var type in types)
            {
                var baseInterface = type.GetInterfaces()
                    .First(a => a.Name != typeof(TRegisterBaseType).Name);
                _serviceCollection.AddTransient(baseInterface, type);
            }
        }
        private void RegisterScope<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach (var type in types)
            {
                var baseInterface = type.GetInterfaces()
                    .First(a => a.Name != typeof(TRegisterBaseType).Name);
                _serviceCollection.AddScoped(baseInterface, type);
            }
        }
        private void RegisterSingleton<TRegisterBaseType>()
        {
            var types = _assemblyDiscovery.DiscoverTypes<TRegisterBaseType>(_namespace);
            foreach (var type in types)
            {
                var baseInterface = type.GetInterfaces()
                    .First(a => a.Name != typeof(TRegisterBaseType).Name);
                _serviceCollection.AddSingleton(baseInterface, type);
            }
        }

    }
}