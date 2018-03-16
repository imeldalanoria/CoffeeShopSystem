using CoffeeShop.EntityFramework.Repositories;
using CoffeeShop.Transport;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.EntityFramework.Persistence
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CoffeeShopContext context) : base(context)
        {
        }
        public IEnumerable<Product> GetDataByOfficeId(int officeId)
        {
            return CoffeeShopContext.Products.Where(c => c.OfficeID == officeId).ToList();
        }

        public Product GetDataByProductName(int? officeId, string productName)
        {
            return CoffeeShopContext.Products.Where(c => c.OfficeID == officeId && c.ProductName == productName).FirstOrDefault();
        }

        public CoffeeShopContext CoffeeShopContext
        {
            get { return Context as CoffeeShopContext; }
        }
    }
}
