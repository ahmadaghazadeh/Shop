namespace AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Services
{
    public interface IOrderRepository
    {
        long GenerateOrderNumber();
        void OrderCreate(Order order);
    }
}
