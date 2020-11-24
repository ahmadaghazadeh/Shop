using System;
using System.Collections.Generic;
using System.Linq;
using AhmadAghazadeh.Framework.AssemblyHelper;
using AhmadAghazadeh.Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AhmadAghazadeh.Shop.Persistence
{
    public class ShopDbContext: DbContextBase
    {
        public ShopDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
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

        public override List<dynamic> DetectEntityMapping()
        {
            var assemblyHelper = new AssemblyDiscovery("AhmadAghazadeh*.dll");
            var getTypes = assemblyHelper.DiscoverTypes<IEntityMapping>("AhmadAghazadeh")
                .Select(Activator.CreateInstance)
                .Cast<dynamic>()
                .ToList();
    
            return getTypes;
        }
    
    }
}
