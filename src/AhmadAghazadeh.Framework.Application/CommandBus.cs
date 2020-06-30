using AhmadAghazadeh.Framework.Core.Application;
using AhmadAghazadeh.Framework.Core.DependencyInjection;

namespace AhmadAghazadeh.Framework.Application
{
    public class CommandBus:ICommandBus
    {
        public void Dispatch<TCommand>(TCommand command) where TCommand : Command
        {
            var commandHandler = ServiceLocator.Current.Resolve<ICommandHandler<TCommand>>();
            commandHandler.Execute(command);
        }
    }
}