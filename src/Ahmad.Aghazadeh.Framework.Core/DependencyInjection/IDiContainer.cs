using System;
using System.Collections.Generic;
using System.Text;

namespace AhmadAghazadeh.Framework.Core.DependencyInjection
{
    public interface IDiContainer
    {
        T Resolve<T>();
    }
}
