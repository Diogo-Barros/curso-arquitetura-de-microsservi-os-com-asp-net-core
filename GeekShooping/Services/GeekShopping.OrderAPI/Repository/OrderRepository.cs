using GeekShopping.OrderAPI.Context;
using GeekShopping.OrderAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly DbContextOptions<PostgreSQLDBContext> _options;

        public OrderRepository(DbContextOptions<PostgreSQLDBContext> options)
        {
            _options = options;
        }

        public async Task<bool> AddOrder(OrderHeader? header)
        {
            if (header == null)
            {
                return false;
            }

            await using var db = new PostgreSQLDBContext(_options);
            db.Headers.Add(header);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid)
        {
            await using var db = new PostgreSQLDBContext(_options);
            var header = await db.Headers.FirstOrDefaultAsync(o => o.Id == orderHeaderId);
            if (header != null)
            {
                header.PaymentStatus = paid;
                db.Headers.Update(header);
                await db.SaveChangesAsync();
            }
        }
    }
}
