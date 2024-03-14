using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class manyTOmany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4254a5ce-ff10-490b-9489-1edb9375fb09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "797fe5a1-eb6c-4591-a1a8-83bff08a8010");

            migrationBuilder.CreateTable(
                name: "portfolios",
                columns: table => new
                {
                    appuserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    stockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolios", x => new { x.appuserId, x.stockId });
                    table.ForeignKey(
                        name: "FK_portfolios_AspNetUsers_appuserId",
                        column: x => x.appuserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_portfolios_stocks_stockId",
                        column: x => x.stockId,
                        principalTable: "stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77263d93-afc9-4c64-aa80-7f57046df851", null, "Admin", "ADMIN" },
                    { "a7d39dfa-c0b4-4790-8cc6-7f80907f2b75", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_portfolios_stockId",
                table: "portfolios",
                column: "stockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "portfolios");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77263d93-afc9-4c64-aa80-7f57046df851");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7d39dfa-c0b4-4790-8cc6-7f80907f2b75");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4254a5ce-ff10-490b-9489-1edb9375fb09", null, "User", "USER" },
                    { "797fe5a1-eb6c-4591-a1a8-83bff08a8010", null, "Admin", "ADMIN" }
                });
        }
    }
}
