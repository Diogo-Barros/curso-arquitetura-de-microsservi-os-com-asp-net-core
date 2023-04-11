using GeekShopping.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Context
{
    public class PostgreSQLDBContext : DbContext
    {
        public PostgreSQLDBContext() { }

        public PostgreSQLDBContext(DbContextOptions<PostgreSQLDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -1,
                Name = "Camiseta No Internet",
                Price = new decimal(69.9),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://raw.githubusercontent.com/Diogo-Barros/curso-arquitetura-de-microsservi-os-com-asp-net-core/main/ProductImages/2_no_internet.jpg",
                CategoryName = "T-shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -2,
                Name = "Capacete Darth Vader Star Wars Black Series",
                Price = new decimal(999.99),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://raw.githubusercontent.com/Diogo-Barros/curso-arquitetura-de-microsservi-os-com-asp-net-core/main/ProductImages/3_vader.jpg",
                CategoryName = "Action Figure"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -3,
                Name = "Star Wars The Black Series Hasbro - Stormtrooper Imperial",
                Price = new decimal(189.99),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://raw.githubusercontent.com/Diogo-Barros/curso-arquitetura-de-microsservi-os-com-asp-net-core/main/ProductImages/4_storm_tropper.jpg",
                CategoryName = "Action Figure"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -4,
                Name = "Camiseta Gamer",
                Price = new decimal(69.99),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://raw.githubusercontent.com/Diogo-Barros/curso-arquitetura-de-microsservi-os-com-asp-net-core/main/ProductImages/5_100_gamer.jpg",
                CategoryName = "T-shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -5,
                Name = "Camiseta SpaceX",
                Price = new decimal(49.99),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://raw.githubusercontent.com/Diogo-Barros/curso-arquitetura-de-microsservi-os-com-asp-net-core/main/ProductImages/6_spacex.jpg",
                CategoryName = "T-shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -6,
                Name = "Camiseta Feminina Coffee Benefits",
                Price = new decimal(69.9),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://raw.githubusercontent.com/Diogo-Barros/curso-arquitetura-de-microsservi-os-com-asp-net-core/main/ProductImages/7_coffee.jpg",
                CategoryName = "T-shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -7,
                Name = "Moletom Com Capuz Cobra Kai",
                Price = new decimal(159.9),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://raw.githubusercontent.com/Diogo-Barros/curso-arquitetura-de-microsservi-os-com-asp-net-core/main/ProductImages/8_moletom_cobra_kay.jpg",
                CategoryName = "Sweatshirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -8,
                Name = "Livro Star Talk – Neil DeGrasse Tyson",
                Price = new decimal(49.9),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://raw.githubusercontent.com/Diogo-Barros/curso-arquitetura-de-microsservi-os-com-asp-net-core/main/ProductImages/9_neil.jpg",
                CategoryName = "Book"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -9,
                Name = "Star Wars Mission Fleet Han Solo Nave Milennium Falcon",
                Price = new decimal(359.99),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://raw.githubusercontent.com/Diogo-Barros/curso-arquitetura-de-microsservi-os-com-asp-net-core/main/ProductImages/10_milennium_falcon.jpg",
                CategoryName = "Action Figure"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -10,
                Name = "Camiseta Elon Musk Spacex Marte Occupy Mars",
                Price = new decimal(59.99),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://raw.githubusercontent.com/Diogo-Barros/curso-arquitetura-de-microsservi-os-com-asp-net-core/main/ProductImages/11_mars.jpg",
                CategoryName = "T-shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -11,
                Name = "Camiseta GNU Linux Programador Masculina",
                Price = new decimal(59.99),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://raw.githubusercontent.com/Diogo-Barros/curso-arquitetura-de-microsservi-os-com-asp-net-core/main/ProductImages/12_gnu_linux.jpg",
                CategoryName = "T-shirt"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = -12,
                Name = "Camiseta Goku Fases",
                Price = new decimal(59.99),
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                ImageURL = "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/13_dragon_ball.jpg",
                CategoryName = "T-shirt"
            });
        }
    }
}
