 

using AhmadAghazadeh.Framework.Core.Application;

namespace AhmadAghazadeh.Framework.Application
{
    public interface ICommandHandler<in TCommand> where TCommand:Command
    {
        void Execute(TCommand command);
    }
}
