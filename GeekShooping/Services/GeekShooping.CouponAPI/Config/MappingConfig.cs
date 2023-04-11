using AutoMapper;
using GeekShooping.CouponAPI.Models;
using GeekShooping.CouponAPI.ValueObjects;

namespace GeekShooping.CouponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(options =>
            {
                options.CreateMap<CouponVO, Coupon>().ReverseMap();
            });
        }
    }
}
