using AhmadAghazadeh.Framework.Core.Application;
using AhmadAghazadeh.Framework.Core.EventBus;
using AhmadAghazadeh.Framework.Core.Facade;

namespace AhmadAghazadeh.Framework.Facade
{
    public abstract class CommandFacadeBase: ICommandFacade
    {

        protected CommandFacadeBase(ICommandBus commandBus, IEventBus eventBus)
        {
            EventBus = eventBus;
            CommandBus = commandBus;
        }
        protected ICommandBus CommandBus { get; }

        protected IEventBus EventBus { get; }
    }
}
