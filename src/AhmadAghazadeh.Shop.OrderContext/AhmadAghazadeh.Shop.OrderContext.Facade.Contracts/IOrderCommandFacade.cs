
using AhmadAghazadeh.Shop.OrderContext.Application.Contracts.Orders;

namespace AhmadAghazadeh.Shop.OrderContext.Facade.Contracts
{
    public interface IOrderCommandFacade
    {
        void CreateOrder(CreateOrderCommand command);
    }
}
