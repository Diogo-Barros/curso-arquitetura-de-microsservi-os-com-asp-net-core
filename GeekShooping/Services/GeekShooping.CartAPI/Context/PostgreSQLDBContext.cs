using GeekShooping.CartAPI.Model;
using GeekShooping.CartAPI.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.CartAPI.Context
{
    public class PostgreSQLDBContext : DbContext
    {
        public PostgreSQLDBContext() { }

        public PostgreSQLDBContext(DbContextOptions<PostgreSQLDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
    }
}
