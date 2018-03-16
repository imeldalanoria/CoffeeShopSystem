using CoffeeShop.Transport;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CoffeeShop.EntityFramework
{
    public class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext() : base("CoffeeShopConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Office> Offices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Product>()
                .HasRequired<Office>(s => s.OfficeInfo)
                .WithMany(g => g.ProductInfos)
                .HasForeignKey<int>(s => s.OfficeID);
        }
    }
}
