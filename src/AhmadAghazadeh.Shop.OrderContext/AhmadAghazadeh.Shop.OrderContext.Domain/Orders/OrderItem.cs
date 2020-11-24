using System;
using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Exceptions;

namespace AhmadAghazadeh.Shop.OrderContext.Domain.Orders
{
    public class OrderItem : EntityBase
    {
        protected OrderItem() { }
        public OrderItem(Guid orderId,Guid productId,int quantity,double price)
        {
            ProductId = productId;
            OrderId = orderId;
            SetQuantity(quantity);
            SetPrice(price);
        }
      
        public Order Order { get; set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }

        private void SetQuantity(int quantity)
        {
            if (quantity == 0)
            {
                throw new QuantityIsNotZeroException();
            }
            Quantity = quantity;
        }

        private void SetPrice(double price)
        {
            if (price == 0)
            {
                throw new PriceIsNotZeroException();
            }
            Price = price;
        }

       
    }
}