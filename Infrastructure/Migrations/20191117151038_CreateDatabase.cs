using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Seat = table.Column<byte>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CarTypeId = table.Column<string>(nullable: true),
                    NumberPlate = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    isWifiAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_CarType_CarTypeId",
                        column: x => x.CarTypeId,
                        principalTable: "CarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "1", 700000m, "Ford EcoSport", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "2", 1500000m, "Ford Everest", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "3", 700000m, "Ford Fiesta", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "4", 500000m, "Kia Morning", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "5", 700000m, "Kia Cerato", (byte)5 });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarTypeId",
                table: "Car",
                column: "CarTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarType");
        }
    }
}
