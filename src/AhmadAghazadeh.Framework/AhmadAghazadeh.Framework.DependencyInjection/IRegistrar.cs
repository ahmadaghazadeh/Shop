using AhmadAghazadeh.Framework.Core.AssemblyHelper;
using Microsoft.Extensions.DependencyInjection;

namespace AhmadAghazadeh.Framework.DependencyInjection
{
    public interface IRegistrar
    {
        void Register(IServiceCollection services, IAssemblyDiscovery assemblyDiscovery);
    }
}