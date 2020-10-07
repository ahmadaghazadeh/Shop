using AhmadAghazadeh.Framework.Core.Application;
using AhmadAghazadeh.Framework.Core.DependencyInjection;

namespace AhmadAghazadeh.Framework.Application
{
    public class CommandBus:ICommandBus
    {
        private readonly IDiContainer diContainer;

        public CommandBus(IDiContainer diContainer)
        {
            this.diContainer = diContainer;
        }
        public void Dispatch<TCommand>(TCommand command) where TCommand : Command
        {
            var commandHandler = diContainer.Resolve<ICommandHandler<TCommand>>();
            var transactionDecorator=new TransactionCommandHandler<TCommand>(commandHandler, diContainer);
            var logCommandDecorator = new LogCommandHandler<TCommand>(transactionDecorator);
            var exceptionDecorator = new ExceptionCommandHandler<TCommand>(logCommandDecorator);
            exceptionDecorator.Execute(command);
        }
    }
}