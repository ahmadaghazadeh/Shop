using System;
using System.Linq;
using System.Linq.Expressions;
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.Persistence;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Services.Customers;
using Microsoft.EntityFrameworkCore;

namespace AhmadAghazadeh.Shop.CustomerContext.Infrastructure.Persistence.Customers
{
   public class CustomerRepository:RepositoryBase<Customer>,ICustomerRepository
    {

        public CustomerRepository(IDbContext context) : base(context)
        {
        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public Customer GetCustomer(Guid commandCustomerId)
        {

            return GetById(commandCustomerId);
        }


        public bool Contains(Expression<Func<Customer, bool>> predicate)
        {
            return context.Set<Customer>().Any(predicate);
        }

        public override IQueryable<Customer> Set()
        {
            return context.Set<Customer>().Include(a => a.Addresses);
        }
    }
}
