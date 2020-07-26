using System;
using System.Linq.Expressions;
using AhmadAghazadeh.Framework.Core.Persistence;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        void CreateCustomer(Customer customer);
        Customer GetCustomer(Guid commandCustomerId);

        bool Contains(Expression<Func<Customer,bool>> predicate);
    }
}