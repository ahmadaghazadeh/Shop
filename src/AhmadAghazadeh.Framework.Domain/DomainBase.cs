using System;
using System.Collections.Generic;
using System.Text;

namespace AhmadAghazadeh.Framework.Domain
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id=Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
