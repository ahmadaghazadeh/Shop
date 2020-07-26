using System;
using AhmadAghazadeh.Framework.Domain;

namespace AhmadAghazadeh.Shop.OrderContext.Domain.Orders
{
    public class OrderItem : EntityBase
    {
        public OrderItem(Guid productId, int quantity, double price)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public Order Order{ get; set; }

        public Guid ProductId { get; private set; }

        public int Quantity { get; private set; }

        public double Price { get; private set; }
    }
}