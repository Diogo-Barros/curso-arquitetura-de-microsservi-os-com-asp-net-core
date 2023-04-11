using GeekShopping.OrderAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.OrderAPI.Context
{
    public class PostgreSQLDBContext : DbContext
    {
        public PostgreSQLDBContext(DbContextOptions<PostgreSQLDBContext> options) : base(options) { }

        public DbSet<OrderHeader> Headers { get; set; }
        public DbSet<OrderDetail> Details { get; set; }
    }
}
