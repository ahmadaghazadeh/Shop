using AhmadAghazadeh.Framework.Application;
using AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Services.Customers;

namespace AhmadAghazadeh.Shop.CustomerContext.Application.Customers
{
    public class UpdateScoreCommandHandler : ICommandHandler<UpdateScoreCommand>
    {
        private readonly ICustomerRepository customerRepository;

        public UpdateScoreCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public void Execute(UpdateScoreCommand command)
        {
            var customer = customerRepository.GetCustomer(command.CustomerId);
            customer.UpdateScore(command.Score);
        }
    }
}