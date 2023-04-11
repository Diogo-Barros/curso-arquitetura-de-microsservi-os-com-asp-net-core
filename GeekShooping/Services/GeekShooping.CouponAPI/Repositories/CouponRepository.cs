using AutoMapper;
using GeekShooping.CouponAPI.Context;
using GeekShooping.CouponAPI.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.CouponAPI.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly PostgreSQLDBContext _context;
        private readonly IMapper _mapper;

        public CouponRepository(PostgreSQLDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            return _mapper.Map<CouponVO>(coupon);
        }
    }
}
