using System;
using AhmadAghazadeh.Framework.Core.DependencyInjection;
using Castle.Windsor;

namespace AhmadAghazadeh.Framework.DependencyInjection
{
    public class DiContainer:IDiContainer
    {
        private readonly WindsorContainer container;

        public DiContainer(WindsorContainer container)
        {
            this.container = container;
        }
        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
