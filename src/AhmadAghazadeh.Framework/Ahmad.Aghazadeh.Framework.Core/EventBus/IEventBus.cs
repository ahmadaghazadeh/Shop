using System;

namespace AhmadAghazadeh.Framework.Core.EventBus
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent domainEvent);
        void Subscribe<TEvent>(Action<dynamic> action);
    }
}