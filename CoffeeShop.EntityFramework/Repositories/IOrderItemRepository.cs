using CoffeeShop.Transport;
using System.Collections.Generic;

namespace CoffeeShop.EntityFramework.Repositories
{
    public interface IOrderItemRepository: IRepository<OrderItem>
    {
        IEnumerable<OrderItem> GetOrderByOfficeId(int officeId);
    }
}
