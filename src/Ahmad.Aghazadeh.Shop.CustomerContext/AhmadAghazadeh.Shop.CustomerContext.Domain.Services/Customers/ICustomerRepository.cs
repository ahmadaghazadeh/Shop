
using System;
using System.Linq.Expressions;
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Services.Customers
{
    public interface ICustomerRepository : IRepository
    {
        void CreateCustomer(Customer customer);
        Customer GetCustomer(Guid commandCustomerId);

        bool Contains(Expression<Func<Customer, bool>> predicate);
    }
}
