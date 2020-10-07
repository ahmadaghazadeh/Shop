using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.Persistence;

namespace AhmadAghazadeh.Framework.Application
{
    public class UnitOfWork:IUnitOfWork{
        private readonly IDbContext context;


        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }
        public void Commit()
        {
            context.SaveChanges();
        }

        public void Rollback()
        {
            context.Dispose();
        }
    }
}