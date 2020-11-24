using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadAghazadeh.Framework.Core.AssemblyHelper
{
    public interface IAssemblyDiscovery
    {
        IEnumerable<T> DiscoverInstances<T>(string searchNamespace);
        IEnumerable<Type> DiscoverTypes<TInterface>(string searchNamespace);
    }
}
