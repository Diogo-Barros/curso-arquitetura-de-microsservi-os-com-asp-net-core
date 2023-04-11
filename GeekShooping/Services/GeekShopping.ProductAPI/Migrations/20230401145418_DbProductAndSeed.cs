using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class DbProductAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    category_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    image_url = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { -12L, "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/13_dragon_ball.jpg", "Camiseta Goku Fases", 59.99m },
                    { -11L, "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/12_gnu_linux.jpg", "Camiseta GNU Linux Programador Masculina", 59.99m },
                    { -10L, "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/11_mars.jpg", "Camiseta Elon Musk Spacex Marte Occupy Mars", 59.99m },
                    { -9L, "Action Figure", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/10_milennium_falcon.jpg", "Star Wars Mission Fleet Han Solo Nave Milennium Falcon", 359.99m },
                    { -8L, "Book", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/9_neil.jpg", "Livro Star Talk – Neil DeGrasse Tyson", 49.9m },
                    { -7L, "Sweatshirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/8_moletom_cobra_kay.jpg", "Moletom Com Capuz Cobra Kai", 159.9m },
                    { -6L, "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/7_coffee.jpg", "Camiseta Feminina Coffee Benefits", 69.9m },
                    { -5L, "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/6_spacex.jpg", "Camiseta SpaceX", 49.99m },
                    { -4L, "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/5_100_gamer.jpg", "Camiseta Gamer", 69.99m },
                    { -3L, "Action Figure", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/4_storm_tropper.jpg", "Star Wars The Black Series Hasbro - Stormtrooper Imperial", 189.99m },
                    { -2L, "Action Figure", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/3_vader.jpg", "Capacete Darth Vader Star Wars Black Series", 999.99m },
                    { -1L, "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://bitbucket.org/diogo_a_barros/curso_arquitetura_de_micro_servicos_asp_net/raw/e6e4eeeaa6cfa954c09dd905bb5a30790744b4bf/ProductImages/2_no_internet.jpg", "Camiseta No Internet", 69.9m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
