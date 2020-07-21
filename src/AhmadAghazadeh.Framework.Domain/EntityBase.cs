using System;
using AhmadAghazadeh.Framework.Core.Domain;
using AhmadAghazadeh.Framework.Core.EventBus;

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
