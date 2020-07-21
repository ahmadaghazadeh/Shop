using System;
using AhmadAghazadeh.Framework.Application;
using AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Domain;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services;

namespace AhmadAghazadeh.Shop.CustomerContext.Application.Customers
{
    public class DeleteAddressCommandHandler:ICommandHandler<DeleteAddressCommand>
    {
        private readonly ICustomerRepository customerRepository;

        public DeleteAddressCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public void Execute(DeleteAddressCommand command)
        {
            var customer = customerRepository.GetCustomer(command.CustomerId);
            customer.DeleteAddress(command.AddressId);
            
            customerRepository.Update(customer);
        }
    }
}