using System;
using System.Collections.Generic;
using System.Text;

namespace AhmadAghazadeh.Shop.OrderContext.Domain.Contracts.Orders
{
    public class OrderCreatedEvent
    {
        public OrderCreatedEvent(Guid orderId, int customerScore)
        {
            OrderId = orderId;
            CustomerScore = customerScore;
        }

        public Guid OrderId { get;private set; }

        public int CustomerScore { get;private set; }
    }
}
