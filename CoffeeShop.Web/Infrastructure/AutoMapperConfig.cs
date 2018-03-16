using AutoMapper;
using CoffeeShop.Model;
using CoffeeShop.Transport;

namespace CoffeeShop.Web.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Office, OfficeModel>();
                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<OrderItem, OrderItemModel>();
                cfg.CreateMap<OfficeModel, Office>()
                    .ForMember(x => x.ProductInfos, opt => opt.Ignore());
                cfg.CreateMap<ProductModel, Product>()
                    .ForMember(x => x.OfficeInfo, opt => opt.Ignore());
            });
        }
    }
}