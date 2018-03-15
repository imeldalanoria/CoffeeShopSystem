using CoffeeShop.EntityFramework.Repositories;
using CoffeeShop.Model;
using CoffeeShop.Transport;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EntityFramework.Persistence
{
    public class OfficeRepository : Repository<Office>, IOfficeRepository
    {
        public OfficeRepository(CoffeeShopContext context) : base(context)
        {
        }
        public CoffeeShopContext CoffeeShopContext
        {
            get { return Context as CoffeeShopContext; }
        }
    }
}
