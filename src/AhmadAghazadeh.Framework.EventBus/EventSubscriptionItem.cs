using System;
using System.Collections.Generic;

namespace AhmadAghazadeh.Framework.EventBus
{
    internal class EventSubscriptionItem
    {
        

        public Type EventType { get; set; }

        public IList<EventHandler> EventHandler { get;  set; }
    }
}