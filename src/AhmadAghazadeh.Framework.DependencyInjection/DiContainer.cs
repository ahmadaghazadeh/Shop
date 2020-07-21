using System;
using AhmadAghazadeh.Framework.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace AhmadAghazadeh.Framework.DependencyInjection
{
    public class DiContainer : IDiContainer
    {
        private readonly IServiceProvider _serviceProvider;

        public DiContainer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T Resolve<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public object Resolve(Type type)
        {
            return _serviceProvider.GetRequiredService(type);
        }
    }
}
