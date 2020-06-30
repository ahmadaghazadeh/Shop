
namespace AhmadAghazadeh.Framework.Core.Application
{
    public interface ICommandBus
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : Command;
    }
}
