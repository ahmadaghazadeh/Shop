using AhmadAghazadeh.Shop.OrderContext.Domain.Orders;

namespace AhmadAghazadeh.Shop.OrderContext.Domain.Services.Orders
{
    public interface IOrderRepository
    {
        long GenerateOrderNumber();
        void OrderCreate(Order order);
    }
}
