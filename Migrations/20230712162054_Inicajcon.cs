using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantAPI5.Migrations
{
    public partial class Inicajcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasDelivery = table.Column<bool>(type: "bit", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addresses_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descritpion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dishes_restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_RestaurantId",
                table: "addresses",
                column: "RestaurantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dishes_RestaurantId",
                table: "dishes",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "dishes");

            migrationBuilder.DropTable(
                name: "restaurants");
        }
    }
}
