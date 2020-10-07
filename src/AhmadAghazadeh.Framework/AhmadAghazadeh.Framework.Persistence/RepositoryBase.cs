using System;
using System.Linq;
using AhmadAghazadeh.Framework.Core.Domain;
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.Domain;

namespace AhmadAghazadeh.Framework.Persistence
{
    public abstract class RepositoryBase<TAggregateRoot> where TAggregateRoot : EntityBase, IAggregateRoot
    {
        protected readonly DbContextBase context;

        protected RepositoryBase(IDbContext context)
        {
            this.context = (DbContextBase)context;
        }

        protected void Create(TAggregateRoot aggregateRoot)
        {
            this.context.Set<TAggregateRoot>().Add(aggregateRoot);
        }

        public abstract IQueryable<TAggregateRoot> Set();
        

        protected TAggregateRoot GetById(Guid id)
        {
          return  Set().ToList().Single(e => e.Id == id);
        }


    }
}