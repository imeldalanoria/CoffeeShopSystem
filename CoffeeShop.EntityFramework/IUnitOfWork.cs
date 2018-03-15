using CoffeeShop.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.EntityFramework
{
    public interface IUnitOfWork : IDisposable
    {
        IOfficeRepository Offices { get; }
        IProductRepository Products { get; }
        int Complete();
    }
}
