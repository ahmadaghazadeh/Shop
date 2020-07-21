 using System;
 using AhmadAghazadeh.Framework.Core.Application;

namespace AhmadAghazadeh.Framework.Application
{
    public class ExceptionCommandHandler<Tcommand> : ICommandHandler<Tcommand> where Tcommand : Command
    {
        private readonly ICommandHandler<Tcommand> handler;

        public ExceptionCommandHandler(ICommandHandler<Tcommand> handler)
        {
            this.handler = handler;
        }
        public void Execute(Tcommand command)
        {
           
                handler.Execute(command);
        }
    }
}