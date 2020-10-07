using System.Linq;
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.Persistence;
using AhmadAghazadeh.Shop.OrderContext.Domain.Orders;
using AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AhmadAghazadeh.Shop.OrderContext.Infrastructure.Persistence.Orders
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbContext context) : base(context)
        {
        }

        public long GenerateOrderNumber()
        {
            return GetNewId();
        }

        public long GetNewId()
        {
            lock (context)
            {
                var sqlParameter = new SqlParameter("@Result", System.Data.SqlDbType.BigInt)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                context.Database.ExecuteSqlRaw($"SELECT @Result=( NEXT VALUE FOR Shared.[Order])", sqlParameter);
                return (long)sqlParameter.Value;
            }
        }

        public void OrderCreate(Order order)
        {
            Create(order);
        }

        public override IQueryable<Order> Set()
        {
            lock (context)
            {
                return context.Set<Order>().Include(o => o.Cart);
            }
        }
    }
}
