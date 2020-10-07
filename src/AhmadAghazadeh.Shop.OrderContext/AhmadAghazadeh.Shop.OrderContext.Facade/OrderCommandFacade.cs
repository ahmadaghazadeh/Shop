
 using AhmadAghazadeh.Framework.Core.Application;
 using AhmadAghazadeh.Framework.Core.EventBus;
 using AhmadAghazadeh.Framework.Facade;
 using AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers;
 using AhmadAghazadeh.Shop.OrderContext.Application.Contracts.Orders;
 using AhmadAghazadeh.Shop.OrderContext.Domain.Contracts.Orders;
 using AhmadAghazadeh.Shop.OrderContext.Facade.Contracts;

 namespace AhmadAghazadeh.Shop.OrderContext.Facade
{
    public class OrderCommandFacade :CommandFacadeBase,IOrderCommandFacade
    {
        public OrderCommandFacade(ICommandBus commandBus,IEventBus eventBus) : base(commandBus, eventBus)
        {
        }


        public void CreateOrder(CreateOrderCommand command)
        {
            EventBus.Subscribe<OrderCreatedEvent>(e =>
            {
                CommandBus.Dispatch(new UpdateScoreCommand(command.CustomerId, e.CustomerScore));
            });
            CommandBus.Dispatch(command);
           
        }
    }
}
