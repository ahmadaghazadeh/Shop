using AhmadAghazadeh.Shop.OrderContext.Domain.Orders;

namespace AhmadAghazadeh.Shop.OrderContext.Domain.Services.Orders
{
    public interface IOrderRepository
    {
        int GenerateOrderNumber();
        void Create(Order order);
    }
}
