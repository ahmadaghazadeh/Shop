using AhmadAghazadeh.Framework.Core.Persistence;

namespace AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Services
{
    public interface IOrderRepository : IRepository<Order>
    {
        long GenerateOrderNumber();
        void OrderCreate(Order order);
    }
}
