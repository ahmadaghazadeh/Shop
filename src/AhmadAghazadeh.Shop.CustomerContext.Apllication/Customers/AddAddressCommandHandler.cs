using System;
using AhmadAghazadeh.Framework.Application;
using AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Domain;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services;

namespace AhmadAghazadeh.Shop.CustomerContext.Application.Customers
{
    public class AddAddressCommandHandler:ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository customerRepository;

        public AddAddressCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public void Execute(AddAddressCommand command)
        {
            var customer = customerRepository.GetCustomer(command.CustomerId);
            var address = new Address(customer.Id, command.PostalCode, command.AddressLine, command.CityId)
            {
                Telephone = command.Telephone,
                Coordinate = command.Coordinate 
            };
            customer.AddAddress(address);
        }
    }
}