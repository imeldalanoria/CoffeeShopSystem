using CoffeeShop.Transport;
using System.Collections.Generic;

namespace CoffeeShop.EntityFramework.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        IEnumerable<Product> GetDataByOfficeId(int officeId);
        Product GetDataByProductName(int? officeId, string productName);
    }
}
