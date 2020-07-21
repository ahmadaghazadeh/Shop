using System;
using System.Collections.Generic;
using System.Linq;
using AhmadAghazadeh.Framework.AssemblyHelper;
using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AhmadAghazadeh.Shop.Persistence
{
    public class ShopDbContext: DbContextBase
    {
        public ShopDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public override List<dynamic> DetectEntityMapping()
        {
            var assemblyHelper = new AssemblyHelper("AhmadAghazadeh.");
            var getType = assemblyHelper.GetTypes(typeof(EntityMappingBase<>))
                .Select(Activator.CreateInstance)
                .Cast<dynamic>()
                .ToList();

            return getType;
        }

    }
}
