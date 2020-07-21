using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AhmadAghazadeh.Framework.Core.Domain;
using AhmadAghazadeh.Framework.Core.EventBus;
using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.OrderContext.Domain.Contracts.Orders;
using AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Exceptions;

namespace AhmadAghazadeh.Shop.OrderContext.Domain.Orders
{
    public class Order:EntityBase,IAggregateRoot<Order>
    {
        private readonly int K=1000;

        public Order(int number, IEnumerable<OrderItem> cart,IEventBus eventBus)
        {
            Number = number;
            SetCart(cart);
            var score=  CalculateScore();
            eventBus.Publish(new OrderCreatedEvent(Id,score));
        }

       

        public int Number { get; set; }

        public decimal Tax { get; set; }

        public decimal ShippingCost { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<OrderItem> Cart { get; set; }
        public IEnumerable<Expression<Func<Order, object>>> GetAggregateExpressions()
        {
            yield return c => c.Cart;
        }

        private void SetCart(IEnumerable<OrderItem> cart)
        {
            var orderItems = cart.ToList();
            if (!orderItems.Any())
            {
                throw new CartRequiredException();
            }

            foreach (var item in orderItems)
            {
                AddOrderItem(item.ProductId, item.Quantity, item.Price);
            } 

            CalculateAmount();
        }

        private void CalculateAmount()
        {
            var subTotal = Cart.Sum(item => item.Price * item.Quantity);
            ShippingCost = subTotal < 1000000 ? 0 : 10000;
            Tax = (ShippingCost + subTotal) * (decimal) 0.13;
            TotalAmount = subTotal + Tax + ShippingCost;
        }

        private void AddOrderItem(Guid productId, int quantity, decimal price)
        {
            Cart.Add(new OrderItem(productId, quantity, price));
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
