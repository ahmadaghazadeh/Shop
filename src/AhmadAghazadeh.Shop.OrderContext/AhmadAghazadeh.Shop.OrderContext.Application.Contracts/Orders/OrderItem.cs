using System;

namespace AhmadAghazadeh.Shop.OrderContext.Application.Contracts.Orders
{
    public class OrderItem
    {
        public Guid ProductId { get;   set; }

        public int Quantity { get;   set; }

        public double Price { get;   set; }
    }
}