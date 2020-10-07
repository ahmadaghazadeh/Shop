using System;
using System.Linq;
using System.Collections.Generic;
using AhmadAghazadeh.Framework.Facade;
using AhmadAghazadeh.Shop.ReadModel.Database.Models;
using AhmadAghazadeh.Shop.ReadModel.Query.Facade.Contracts.Customer.DataContracts;

namespace AhmadAghazadeh.Shop.ReadModel.Query.Facade.Customers
{
   public class CustomerQueryFacade: QueryFacadeBase
    {
        public IList<CustomerDto> GetCustomers(string keyword)
        {
            
            using (var context=new ShopContext())
            {
                return (from customer in context.Customers
                        where customer.FirstName.Contains(keyword) ||
                              customer.LastName.Contains(keyword) ||
                              customer.Email.Contains(keyword) ||
                              customer.NationalCode.Contains(keyword)
                        let hasAddress = customer.Addresses.Any()
                    select new CustomerDto()
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        Email = customer.Email,
                        LastName = customer.LastName,
                        HasAddress = hasAddress,
                        NationalCode = customer.NationalCode
                    }).ToList();
            }
        }
    }
}
