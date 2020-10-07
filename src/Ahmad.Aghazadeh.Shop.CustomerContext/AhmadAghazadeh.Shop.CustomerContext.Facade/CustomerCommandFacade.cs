using AhmadAghazadeh.Framework.Core.Application;
using AhmadAghazadeh.Framework.Core.EventBus;
using AhmadAghazadeh.Framework.Facade;
using AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Facade.Contracts;

namespace AhmadAghazadeh.Shop.CustomerContext.Facade
{
    public  class CustomerCommandFacade:CommandFacadeBase, ICustomerCommandFacade
    {
        public CustomerCommandFacade(ICommandBus commandBus,IEventBus eventBus) : base(commandBus, eventBus)
        {

        }

        public void SignUp(SignUpCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void AddAddress(AddAddressCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteAddress(DeleteAddressCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
