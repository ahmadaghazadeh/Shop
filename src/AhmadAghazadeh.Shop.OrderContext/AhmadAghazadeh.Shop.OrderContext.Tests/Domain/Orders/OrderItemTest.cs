using System;
using AhmadAghazadeh.Shop.OrderContext.Domain.Orders;
using AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AhmadAghazadeh.Shop.OrderContext.Tests.Domain.Orders
{
    [TestClass]
    public class OrderItemTest
    {
        [TestMethod, TestCategory("ProductId")]
        public void ValidProductId_Retrieve()
        {
            var productId = new Guid();
            var order = new OrderItem(new Guid(),productId,1000,1000);

            Assert.AreEqual(productId, order.ProductId);
        }

        [TestMethod, TestCategory("Quantity")]
        public void ValidQuantity_Retrieve()
        {
            var quantity = 2;
            var order = new OrderItem(new Guid(), new Guid(), quantity,1000);

            Assert.AreEqual(quantity, order.Quantity);
        }

        [TestMethod, TestCategory("Quantity")]
        [ExpectedException(typeof(QuantityIsNotZeroException))]
        public void QuantityIs0_ThrowException()
        {
            var order = new OrderItem(new Guid(), new Guid(), 0, 1000);

        }

        [TestMethod, TestCategory("Price")]
        public void ValidPrice_Retrieve()
        {
            var price = 2000;
            var order = new OrderItem(new Guid(), new Guid(), 2, price);

            Assert.AreEqual(price, order.Price);
        }

        [TestMethod, TestCategory("Price")]
        [ExpectedException(typeof(PriceIsNotZeroException))]
        public void PriceIs0_ThrowException()
        {
            var order = new OrderItem(new Guid(), new Guid(), 2, 0);

        }

    }
}
