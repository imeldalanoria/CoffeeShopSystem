using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CoffeeShop.EntityFramework;
using CoffeeShop.EntityFramework.Persistence;
using CoffeeShop.EntityFramework.Repositories;
using CoffeeShop.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoffeeShop.Web.Infrastructure
{
    public class CoffeeShopDependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly().BasedOn(typeof(OfficeController)).LifestyleTransient(),
                Classes.FromThisAssembly().BasedOn(typeof(OrderController)).LifestyleTransient(),
                Classes.FromThisAssembly().BasedOn(typeof(ProductController)).LifestyleTransient(),
                Component.For<DbContext>().ImplementedBy<CoffeeShopContext>(),
                Component.For(typeof(Repository<>)).ImplementedBy<OfficeRepository>(),
                Component.For(typeof(Repository<>)).ImplementedBy<ProductRepository>(),
                Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>))
                );

        }
    }
}