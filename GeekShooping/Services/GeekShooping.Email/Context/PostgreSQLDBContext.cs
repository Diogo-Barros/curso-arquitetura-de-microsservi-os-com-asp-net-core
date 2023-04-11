using GeekShooping.Email.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.Email.Context
{
    public class PostgreSQLDBContext : DbContext
    {
        public PostgreSQLDBContext(DbContextOptions<PostgreSQLDBContext> options) : base(options) { }

        public DbSet<EmailLog> Emails { get; set; }
    }
}
