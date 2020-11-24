using System;
using System.Collections.Generic;
using System.Linq;
using AhmadAghazadeh.Framework.Core.Domain;
using AhmadAghazadeh.Framework.Core.EventBus;
using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.OrderContext.Domain.Contracts.Orders;
using AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Exceptions;

namespace AhmadAghazadeh.Shop.OrderContext.Domain.Orders
{
    public class Order : EntityBase, IAggregateRoot
    {
        private readonly int K = 1000;
        public ICollection<OrderItem> Cart{ get; private set; }=new HashSet<OrderItem>();
        public long Number { get;private set; }
        public double TotalAmount { get;private set; }
        public double ShippingCost { get;private set; }
        public double Tax { get;private set; }
        private readonly IEventBus eventBus;

        protected Order() { }
        public Order(long number, IEventBus eventBus)
        {
            Number = number;
            
            this.eventBus = eventBus;
        }

        public void SetOrderItems(ICollection<OrderItem> orderItems)
        {
            if (orderItems.Count == 0)
            {
                throw new CartRequiredException();
            }

            foreach (var orderItem in orderItems)
            {
                Cart.Add(orderItem);
            }
            CalculateAmount();
            var score = CalculateScore();
            eventBus.Publish(new OrderCreatedEvent(Id, score));
        }

        private void CalculateAmount()
        {
         var subPrice = Cart.Sum(i => i.Price * i.Quantity);
         ShippingCost = subPrice >= 200000 ? 0 : 10000;
         Tax = (subPrice + ShippingCost) * .13;
         TotalAmount = subPrice +ShippingCost+Tax;
        }
        private int CalculateScore()
        {
            if (TotalAmount < 100 * K)
            {
                return 1;
            }

            if (TotalAmount < 200 * K)
            {
                return 2;
            }

            if (TotalAmount < 500 * K)
            {
                return 5;
            }
            return 10;
        }
    }
}
