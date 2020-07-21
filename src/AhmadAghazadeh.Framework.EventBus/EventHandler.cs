using System;

namespace AhmadAghazadeh.Framework.EventBus
{
    public class EventHandler
    {
        public EventHandler(Action<object> handlingAction)
        {
            this.Action = handlingAction;
        }

        public Action<object> Action { get; }
    }
}