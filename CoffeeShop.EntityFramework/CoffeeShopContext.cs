using CoffeeShop.Transport;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
