using System;
using System.Linq;
using AhmadAghazadeh.Framework.Core.Domain;
using AhmadAghazadeh.Framework.Core.Persistence;
using AhmadAghazadeh.Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace AhmadAghazadeh.Framework.Persistence
{
    public abstract class RepositoryBase<TAggregateRoot> where TAggregateRoot : EntityBase, IAggregateRoot<TAggregateRoot>,new()
    {
        protected readonly DbContextBase context;

        protected RepositoryBase(IDbContext context)
        {
            this.context = (DbContextBase)context;
        }

        protected void Update(TAggregateRoot aggregateRoot)
        {
            this.context.Entry(aggregateRoot).State = EntityState.Modified;
        }

        public IQueryable<TAggregateRoot> Set
        {
            get
            {
                var set = context.Set<TAggregateRoot>().AsQueryable();
                var includeExpression = new TAggregateRoot().GetAggregateExpressions();
                foreach (var expression in includeExpression)
                {
                    set.Include(expression);
                }

                return set;
            }
        }

        protected TAggregateRoot GetById(Guid id)
        {
          return  Set.Single(e => e.Id == id);
        }


    }
}