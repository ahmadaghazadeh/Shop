using System.Collections.Generic;
using AhmadAghazadeh.Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AhmadAghazadeh.Framework.Persistence
{
    public abstract class DbContextBase:DbContext,IDbContext
    { 

      

        protected DbContextBase(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entityMapping = DetectEntityMapping();

            entityMapping.ForEach(a =>
            {
                modelBuilder.ApplyConfiguration(a);

            });
        }

        public abstract List<dynamic> DetectEntityMapping();

        public void Migrate()
        {
            base.Database.Migrate();
        }


    }
}
