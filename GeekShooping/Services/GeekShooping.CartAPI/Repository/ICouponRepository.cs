using GeekShooping.CartAPI.ValueObjects;

namespace GeekShooping.CartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode, string token);
    }
}
