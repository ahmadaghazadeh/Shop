using System;
using System.Collections.Generic;
using AhmadAghazadeh.Framework.Core.Application;

namespace AhmadAghazadeh.Shop.OrderContext.Application.Contracts.Orders
{
    public class CreateOrderCommand:Command
    {
        public Guid CustomerId { get; set; }

        public ICollection<OrderItem> Cart { get; set; }

    }
}
