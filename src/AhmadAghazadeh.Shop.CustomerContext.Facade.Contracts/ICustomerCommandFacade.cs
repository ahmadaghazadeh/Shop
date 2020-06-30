using System;
using System.Collections.Generic;
using System.Text;
using AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers;

namespace AhmadAghazadeh.Shop.CustomerContext.Facade.Contracts
{
    public interface ICustomerCommandFacade
    {

        void SignUp(SignUpCommand command);

        void AddAddress(AddAddressCommand command);

        void DeleteAddress(DeleteAddressCommand command);
    }
}
