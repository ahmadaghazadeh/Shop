using System.Collections.Generic;
using AhmadAghazadeh.Shop.ReadModel.Query.Facade.Contracts.Customer.DataContracts;

namespace AhmadAghazadeh.Shop.ReadModel.Query.Facade.Contracts.Customer
{
    public interface ICustomerQueryFacade
    {
        IList<CustomerDto> GetCustomers(string keyword);
    }
}
