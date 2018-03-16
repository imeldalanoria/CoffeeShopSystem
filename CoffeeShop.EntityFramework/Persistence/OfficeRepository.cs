using CoffeeShop.EntityFramework.Repositories;
using CoffeeShop.Transport;
using System.Linq;

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

        public Office GetByOfficeId(int officeId)
        {
            return CoffeeShopContext.Offices.Where(o => o.OfficeID == officeId).FirstOrDefault();
        }
    }
}
