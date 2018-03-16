using CoffeeShop.EntityFramework.Repositories;
using CoffeeShop.Transport;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.EntityFramework.Persistence
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(CoffeeShopContext context) : base(context)
        {
        }
        public CoffeeShopContext CoffeeShopContext
        {
            get { return Context as CoffeeShopContext; }
        }

        public IEnumerable<OrderItem> GetOrderByOfficeId(int officeId)
        {
            return CoffeeShopContext.OrderItems.Where(c => c.OfficeID == officeId).ToList();
        }
    }
}
