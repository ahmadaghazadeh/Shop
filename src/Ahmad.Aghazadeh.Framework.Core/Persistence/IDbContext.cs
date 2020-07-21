using System;
using System.Collections.Generic;
using System.Text;

namespace AhmadAghazadeh.Framework.Core.Persistence
{
    public interface IDbContext: IDisposable
    {
        int SaveChanges();
        void Migrate();
        new void Dispose();
 
    }
}
