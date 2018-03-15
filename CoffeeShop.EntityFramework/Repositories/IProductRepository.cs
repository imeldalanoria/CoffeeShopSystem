using CoffeeShop.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EntityFramework.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        IEnumerable<Product> GetDataByOfficeId(int officeId);
        Product GetDataByProductName(int? officeId, string productName);
    }
}
