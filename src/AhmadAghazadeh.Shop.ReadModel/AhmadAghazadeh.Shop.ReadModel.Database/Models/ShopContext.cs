using Microsoft.EntityFrameworkCore;

namespace AhmadAghazadeh.Shop.ReadModel.Database.Models
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=Shop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Shop"); 

                entity.HasIndex(e => e.CustomerId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddressLine)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Coordinate).HasMaxLength(1);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telephone)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City", "Basic");

                entity.HasIndex(e => e.StateId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_City_State_CityId");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Shop");

                entity.HasIndex(e => e.NationalCode)
                    .HasName("NationalCode")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.NationalCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State", "Basic");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.HasSequence("Address", "Shared");

            modelBuilder.HasSequence("Customer", "Shared");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
