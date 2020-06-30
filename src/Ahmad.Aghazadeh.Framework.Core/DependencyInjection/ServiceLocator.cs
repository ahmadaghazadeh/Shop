using System;
using System.Collections.Generic;
using System.Text;

namespace AhmadAghazadeh.Framework.Core.DependencyInjection
{
    public class ServiceLocator
    {
        public ServiceLocator(IDiContainer container)
        {
            if (Current != null) return;
            Current = container;
        }
        public static IDiContainer Current { get; set; }
    }
}
