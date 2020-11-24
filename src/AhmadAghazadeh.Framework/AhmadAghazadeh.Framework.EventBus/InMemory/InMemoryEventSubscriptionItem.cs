using System;
using System.Collections.Generic;

namespace AhmadAghazadeh.Framework.EventBus
{
    internal class InMemoryEventSubscriptionItem
    {
        

        public Type EventType { get; set; }

        public IList<InMemoryEventHandler> EventHandler { get;  set; }
    }
}