using CoffeeShop.EntityFramework.Repositories;
using System;

namespace CoffeeShop.EntityFramework
{
    public interface IUnitOfWork : IDisposable
    {
        IOfficeRepository Offices { get; }
        IProductRepository Products { get; }
        IOrderItemRepository OrderItems { get; }
        int Complete();
    }
}
