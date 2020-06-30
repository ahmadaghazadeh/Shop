using System;
using AhmadAghazadeh.Framework.Core.Application;

namespace AhmadAghazadeh.Framework.Facade
{
    public abstract class FacadeCommandBase
    {
        protected FacadeCommandBase(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }
        protected ICommandBus CommandBus { get; }
    }
}
