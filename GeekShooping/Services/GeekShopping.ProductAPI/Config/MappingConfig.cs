using AutoMapper;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.ValueObjects;

namespace GeekShopping.ProductAPI.Config
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
        }
    }
}
