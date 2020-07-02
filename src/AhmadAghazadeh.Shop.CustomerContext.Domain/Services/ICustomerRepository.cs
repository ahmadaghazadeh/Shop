using System;
using System.Linq.Expressions;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Services
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        Customer GetCustomer(Guid commandCustomerId);
        void Update(Customer customer);

        bool Contains(Expression<Func<Customer,bool>> predicate);
    }
}