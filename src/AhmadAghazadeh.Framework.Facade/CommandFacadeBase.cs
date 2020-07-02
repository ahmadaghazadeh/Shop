using System;
using AhmadAghazadeh.Framework.Core.Application;

namespace AhmadAghazadeh.Framework.Facade
{
    public abstract class CommandFacadeBase
    {
        protected CommandFacadeBase(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }
        protected ICommandBus CommandBus { get; }
    }
}
