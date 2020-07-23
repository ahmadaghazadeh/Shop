using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.Persistence;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services;
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
            context.Set<Customer>().Add(customer);
        }

        public Customer GetCustomer(Guid commandCustomerId)
        {

            return GetById(commandCustomerId);
        }


        public bool Contains(Expression<Func<Customer, bool>> predicate)
        {
            return context.Set<Customer>().Any(predicate);
        }

        void ICustomerRepository.Update(Customer customer)
        {
            Update(customer);
        }
    }
}
