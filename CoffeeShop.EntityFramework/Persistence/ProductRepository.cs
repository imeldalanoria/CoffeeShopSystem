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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CoffeeShopContext context) : base(context)
        {
        }
        public IEnumerable<Product> GetDataByOfficeId(int officeId)
        {
            return CoffeeShopContext.Products.Where(c => c.OfficeInfo.OfficeID == officeId).ToList();
        }

        public Product GetDataByProductName(int? officeId, string productName)
        {
            return CoffeeShopContext.Products.Where(c => c.OfficeInfo.OfficeID == officeId && c.ProductName == productName).FirstOrDefault();
        }

        public CoffeeShopContext CoffeeShopContext
        {
            get { return Context as CoffeeShopContext; }
        }
    }
}
