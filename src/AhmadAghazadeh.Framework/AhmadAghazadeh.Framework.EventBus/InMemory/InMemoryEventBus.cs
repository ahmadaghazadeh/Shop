using System;
using System.Collections.Generic;
using System.Linq;
using AhmadAghazadeh.Framework.Core.EventBus;

namespace AhmadAghazadeh.Framework.EventBus
{
    public class InMemoryEventBus:IEventBus
    {
        private readonly IList<InMemoryEventSubscriptionItem> subscriptionItems;

        public InMemoryEventBus()
        {
            subscriptionItems = new List<InMemoryEventSubscriptionItem>();
        }
        public void Publish<TEvent>(TEvent domainEvent)
        {
            var existEvent = subscriptionItems.SingleOrDefault(e => e.EventType == typeof(TEvent));
            if (existEvent != null)
            {
                foreach (var eventHandler in existEvent.EventHandler)
                {
                    eventHandler.Action(domainEvent);
                }
            }
        }

        public void Subscribe<TEvent>(Action<dynamic> action)
        {
            var existEvent = subscriptionItems.SingleOrDefault(e => e.EventType == typeof(TEvent));
            if (existEvent == null)
            {
                var newSubscription = new InMemoryEventSubscriptionItem()
                {
                    EventType = typeof(TEvent),
                    EventHandler = new List<InMemoryEventHandler>() { new InMemoryEventHandler(action) }
                };
                subscriptionItems.Add(newSubscription);
            }
            else
            {
                existEvent.EventHandler.Add(new InMemoryEventHandler(action));
            }
            
        }
    }
}
