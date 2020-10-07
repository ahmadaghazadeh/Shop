using System;
using System.Collections.Generic;
using System.Linq;
using AhmadAghazadeh.Framework.Core.EventBus;
using AhmadAghazadeh.Shop.OrderContext.Domain.Contracts.Orders;
using AhmadAghazadeh.Shop.OrderContext.Domain.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AhmadAghazadeh.Shop.OrderContext.Tests.Domain.Orders
{
    [TestClass]
    public class OrderTest
    {
        readonly Mock<IEventBus> enventBus = new Mock<IEventBus>();

        [TestInitialize]
        public void SetUp()
        {
            enventBus.Setup(bus => bus.Publish(new OrderCreatedEvent(new Guid(), 55)));

        }

        [TestMethod,TestCategory("Number")]
        public void ValidNumber_Retrieve()
        {
            var number = 123L;
            var order= Initialize(number:number);

            Assert.AreEqual(number,order.Number);
        }



        [TestMethod, TestCategory("Cart")]
        public void AddCart_Retrieve()
        {
            var quantity = 2;
            var price = 10000;
            var productId=new Guid();
            var order = Initialize(quantity: quantity, price: price, productId: productId);

            var actual = order.Cart.First();
            Assert.AreEqual(price, actual.Price);
            Assert.AreEqual(productId, actual.ProductId);
            Assert.AreEqual(quantity, actual.Quantity);
        }

        [TestMethod, TestCategory("TotalAmount")]
        public void AddNewOrderItemTotalAmountLessThan200000_TotalPriceIsSumTaxAndQuantityMultiplyPriceNewOrderItemPlus10000()
        {
            var quantity = 2;
            var price = 10000;
            var order = Initialize(quantity: quantity, price: price);

            var expected = quantity * price+10000+order.Tax;

            Assert.AreEqual(expected, order.TotalAmount);
        }

        [TestMethod, TestCategory("TotalAmount")]
        public void AddNewOrderItemTotalAmountEqualOrGreaterThan20000_TotalPriceIsSumTaxAndQuantityMultiplyPriceNewOrderItem()
        {
            var quantity = 2;
            var price = 100000;
            var order = Initialize(quantity: quantity, price: price);

            var expected = quantity * price + 0 + order.Tax;

            Assert.AreEqual(expected, order.TotalAmount);
        }

        [TestMethod, TestCategory("ShippingCost")]
        public void SumOfAllItemsQuantityMultiplyPriceIsEqualOrGreaterThan200000_ShoppingCostIs0()
        {
            var order = Initialize(quantity:2,price:100000);

            Assert.AreEqual(0, order.ShippingCost);
        }

        [TestMethod, TestCategory("ShippingCost")]
        public void SumOfAllItemsQuantityMultiplyPriceIsEqualOrLessThan200000_ShoppingCostIs0()
        {
            var order = Initialize(quantity:2,price:100000);

            Assert.AreEqual(0, order.ShippingCost);
        }
        [TestMethod, TestCategory("Tax")]
        public void ValidTax_SumShippingCostAndSumAllOfOrderItemsMultiply13Percent()
        {
            var quantity = 2;
            var price = 100000;
            var order = Initialize(quantity: quantity, price: price);

            var expected = ((quantity * price) + order.ShippingCost) * 0.13;

            Assert.AreEqual(expected, order.Tax);
        }

        [TestMethod, TestCategory("OrderCreatedEvent")]
        public void CreatedOrder_RaiseOrderCreatedEvent()
        {
            var quantity = 2;
            var price = 50000;

            Initialize(quantity: quantity, price: price);
            enventBus.Verify(
                e =>e.Publish(It.IsAny<OrderCreatedEvent>())
                , Times.Once);

        }


        private Order Initialize(
            long number=123L,int quantity=2,double price=100000,Guid productId=new Guid())
        {

            var order = new Order(number, enventBus.Object);
            var items = new LinkedList<OrderItem>();
            items.AddFirst(new OrderItem(order.Id,
                productId,
                quantity,
                price));
            order.SetOrderItems(items);

            return order;
        }
    }
}
