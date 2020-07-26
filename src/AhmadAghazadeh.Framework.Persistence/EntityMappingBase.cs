using System.Data;
using AhmadAghazadeh.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AhmadAghazadeh.Framework.Persistence
{
    public abstract class EntityMappingBase<TEntity> : IEntityTypeConfiguration<TEntity>, IEntityMapping
        where TEntity : EntityBase
    {

       
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        protected void Initial(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString())
                .IsRequired().ValueGeneratedNever();
            builder.HasKey(c=>c.Id);
            
            builder.ToTable(typeof(TEntity).Name, typeof(TEntity).Namespace?.Split('.')[1]);
        }
    }

    
}
