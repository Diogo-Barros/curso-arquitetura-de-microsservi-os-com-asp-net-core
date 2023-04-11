using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Contexts;
using GeekShopping.IdentityServer.Model;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly PostgreSQLDbContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(PostgreSQLDbContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public async void Initialize()
        {
            /*
             * Se roles já exitirem o banco de dados já esta iniciado
             * Então somente sai do metodo
             */
            if (await _role.FindByNameAsync(IdentityConfiguration.Admin) != null)
            {
                return;
            }

            /* Criando as roles */
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

            /* Criando o usuário administrador, atribuindo a role e as claims */
            ApplicationUser admin = new ApplicationUser
            {
                UserName = "diogo-admin",
                Email = "diogo-admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (99) 12345-6789",
                FirstName = "Diogo",
                LastName = "Admin"
            };

            _user.CreateAsync(admin, "Teste@123").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();
            _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)

            }).GetAwaiter().GetResult();

            /* Criando o usuário cliente, atribuindo a role e as claims */
            ApplicationUser client = new ApplicationUser
            {
                UserName = "diogo-client",
                Email = "diogo-client@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (99) 12345-6789",
                FirstName = "Diogo",
                LastName = "Client"
            };

            _user.CreateAsync(client, "Teste@123").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();
            _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)

            }).GetAwaiter().GetResult();
        }
    }
}
