namespace CoffeeShop.EntityFramework.Migrations
{
    using CoffeeShop.Transport;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoffeeShop.EntityFramework.CoffeeShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CoffeeShop.EntityFramework.CoffeeShopContext context)
        {
            Office office1 = new Office()
            {
                OfficeName = "Manila",
                PantryName = "Pantry1",
                ProductInfos = new List<Product>()
                {
                    new Product() { ProductName = "Coffee Beans", Unit = 15 },
                    new Product() { ProductName = "Sugar", Unit = 15},
                    new Product() { ProductName = "Milk", Unit = 15  }
                }
            };
            Office office2 = new Office()
            {
                OfficeName = "London",
                PantryName = "Pantry2",
                ProductInfos = new List<Product>()
                {
                    new Product() { ProductName = "Coffee Beans", Unit = 15  },
                    new Product() { ProductName = "Sugar", Unit = 15  },
                    new Product() { ProductName = "Milk", Unit = 15  }
                }
            };

            context.Offices.Add(office1);
            context.Offices.Add(office2);
            base.Seed(context);
        }
    }
}
