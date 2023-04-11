using GeekShopping.IdentityServer.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Contexts
{
    public class PostgreSQLDbContext : IdentityDbContext<ApplicationUser>
    {
        public PostgreSQLDbContext() { }

        public PostgreSQLDbContext(DbContextOptions<PostgreSQLDbContext> options) : base(options) { }
    }
}
