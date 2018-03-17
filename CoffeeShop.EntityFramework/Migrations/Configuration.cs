namespace CoffeeShop.EntityFramework.Migrations
{
    using CoffeeShop.Transport;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

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
                HasProduct = true,
                ProductInfos = new List<Product>()
                {
                    new Product() { ProductName = "Coffee Beans", Unit = 45 , OfficeID =1},
                    new Product() { ProductName = "Sugar", Unit = 45, OfficeID =1},
                    new Product() { ProductName = "Milk", Unit = 45 , OfficeID =1 }
                }
            };
            Office office2 = new Office()
            {
                OfficeName = "London",
                PantryName = "Pantry2",
                HasProduct = true,
                ProductInfos = new List<Product>()
                {
                    new Product() { ProductName = "Coffee Beans", Unit = 45  , OfficeID =2},
                    new Product() { ProductName = "Sugar", Unit = 45 , OfficeID =2 },
                    new Product() { ProductName = "Milk", Unit = 45  , OfficeID =2}
                }
            };

            context.Offices.Add(office1);
            context.Offices.Add(office2);
            base.Seed(context);
        }
    }
}
