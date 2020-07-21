using System;
using System.Collections.Generic;
using System.Linq;
using AhmadAghazadeh.Framework.Core.EventBus;

namespace AhmadAghazadeh.Framework.EventBus
{
    public class EventBus:IEventBus
    {
        private readonly IList<EventSubscriptionItem> subscriptionItems;

        public EventBus()
        {
            subscriptionItems = new List<EventSubscriptionItem>();
        }
        public void Publish<TEvent>(TEvent domainEvent)
        {
            var existEvent = subscriptionItems.Single(e => e.EventType == typeof(TEvent));
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
            var existEvent = subscriptionItems.Single(e => e.EventType == typeof(TEvent));
            if (existEvent == null)
            {
                var newSubscription = new EventSubscriptionItem()
                {
                    EventType = typeof(TEvent),
                    EventHandler = new List<EventHandler>() { new EventHandler(action) }
                };
                subscriptionItems.Add(newSubscription);
            }
            else
            {
                existEvent.EventHandler.Add(new EventHandler(action));
            }
            
        }
    }
}
