using CoffeeShop.Transport;

namespace CoffeeShop.EntityFramework.Repositories
{
    public interface IOfficeRepository: IRepository<Office>
    {
       Office GetByOfficeId(int officeId);
    }
}
