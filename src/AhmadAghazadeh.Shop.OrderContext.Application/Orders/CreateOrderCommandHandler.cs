using System.Linq;
using AhmadAghazadeh.Framework.Application;
using AhmadAghazadeh.Framework.Core.EventBus;
using AhmadAghazadeh.Shop.OrderContext.Application.Contracts.Orders;
using AhmadAghazadeh.Shop.OrderContext.Domain.Orders;
using AhmadAghazadeh.Shop.OrderContext.Domain.Services.Orders;

namespace AhmadAghazadeh.Shop.OrderContext.Application.Orders
{
    public class CreateOrderCommandHandler:ICommandHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IEventBus eventBus;

        public CreateOrderCommandHandler(IOrderRepository orderRepository,IEventBus eventBus)
        {
            this.orderRepository = orderRepository;
            this.eventBus = eventBus;
        }
        public void Execute(CreateOrderCommand command)
        {

            var orderNumber = orderRepository.GenerateOrderNumber();
            var cart = command.Cart.Select(c => new Domain.Orders.OrderItem(c.ProductId, c.Quantity, c.Price));
            var order = new Order(orderNumber, cart, eventBus);
            orderRepository.Create(order);

        }
    }
}
