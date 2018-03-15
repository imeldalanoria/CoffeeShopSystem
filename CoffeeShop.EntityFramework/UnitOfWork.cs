using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.EntityFramework.Persistence;
using CoffeeShop.EntityFramework.Repositories;

namespace CoffeeShop.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoffeeShopContext _context;

        public UnitOfWork(CoffeeShopContext context)
        {
            _context = context;
            Offices = new OfficeRepository(_context);
            Products = new ProductRepository(_context);
        }

        public IOfficeRepository Offices { get; private set; }
        public IProductRepository Products { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
