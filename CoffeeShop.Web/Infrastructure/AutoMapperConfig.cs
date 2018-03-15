using AutoMapper;
using CoffeeShop.Model;
using CoffeeShop.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Web.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Office, OfficeModel>();
                cfg.CreateMap<Product, ProductModel>();
            });
        }
    }
}