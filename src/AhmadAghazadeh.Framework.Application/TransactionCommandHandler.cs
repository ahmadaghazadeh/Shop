using System;
using AhmadAghazadeh.Framework.Core.Application;
using AhmadAghazadeh.Framework.Core.DependencyInjection;
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.Persistence;

namespace AhmadAghazadeh.Framework.Application
{
    public class TransactionCommandHandler<Tcommand> : ICommandHandler<Tcommand> where Tcommand :Command
    {
        private readonly ICommandHandler<Tcommand> handler;
        private readonly IDiContainer diContainer;

        public TransactionCommandHandler(ICommandHandler<Tcommand> handler, IDiContainer diContainer)
        {
            this.handler = handler;
            this.diContainer = diContainer;
        }
        public void Execute(Tcommand command)
        {
            var unitOfWork= diContainer.Resolve<IUnitOfWork>();
            try
            {
                handler.Execute(command);
                unitOfWork.Commit();
            }
            catch  
            {
                unitOfWork.Rollback();
                throw;
            }
           
        }
    }
}