using AutoMapper;
using GeekShooping.CartAPI.Model;
using GeekShooping.CartAPI.ValueObjects;

namespace GeekShooping.CartAPI.Config
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>().ReverseMap();
                config.CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailVO, CartDetail>().ReverseMap();
                config.CreateMap<CartVO, Cart>().ReverseMap();
            });
        }
    }
}
