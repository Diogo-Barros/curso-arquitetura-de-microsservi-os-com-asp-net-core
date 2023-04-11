using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShooping.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingCouponDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "id", "coupon_code", "discount_amount" },
                values: new object[,]
                {
                    { -2L, "GEEK_SHOOPING_2023_05", 15m },
                    { -1L, "GEEK_SHOOPING_2023_04", 10m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "id",
                keyValue: -2L);

            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "id",
                keyValue: -1L);
        }
    }
}
