using AhmadAghazadeh.Framework.Core.Application;

namespace AhmadAghazadeh.Framework.Application
{
    public class LogCommandHandler<Tcommand> : ICommandHandler<Tcommand> where Tcommand : Command
    {
        private readonly ICommandHandler<Tcommand> handler;
        public LogCommandHandler(ICommandHandler<Tcommand> handler)
        {
            this.handler = handler;
        }
        public void Execute(Tcommand command)
        {
            handler.Execute(command);
        }
    }
}