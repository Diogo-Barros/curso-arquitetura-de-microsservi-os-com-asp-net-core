using GeekShooping.CouponAPI.ValueObjects;

namespace GeekShooping.CouponAPI.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode);
    }
}
