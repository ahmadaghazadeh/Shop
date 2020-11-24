using System.Collections.Generic;
using System.Text;
using AhmadAghazadeh.Framework.Application;
using AhmadAghazadeh.Framework.Core.Security;
using AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Services.Customers;

namespace AhmadAghazadeh.Shop.CustomerContext.Application.Customers
{
    public class SignUpCommandHandler:ICommandHandler<SignUpCommand>
    {
        private readonly INationalCodeDuplicationChecker nationalCodeDuplicationChecker;
        private readonly IHashProvider hashProvider;
        private readonly ICustomerRepository customerRepository;

        public SignUpCommandHandler(
            INationalCodeDuplicationChecker nationalCodeDuplicationChecker,
            IHashProvider hashProvider,
            ICustomerRepository customerRepository)
        {
            this.nationalCodeDuplicationChecker = nationalCodeDuplicationChecker;
            this.hashProvider = hashProvider;
            this.customerRepository = customerRepository;
        }
        public void Execute(SignUpCommand command)
        {
           var customer=new Customer(
               nationalCodeDuplicationChecker,
               hashProvider,
               command.FirstName,
               command.LastName,
               command.NationalCode,
               command.Password,
               command.Email
               );

           customerRepository.CreateCustomer(customer);
        }
    }
}
