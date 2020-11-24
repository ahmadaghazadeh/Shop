using System;

namespace AhmadAghazadeh.Framework.EventBus
{
    public class InMemoryEventHandler
    {
        public InMemoryEventHandler(Action<object> handlingAction)
        {
            this.Action = handlingAction;
        }

        public Action<object> Action { get; }
    }
}