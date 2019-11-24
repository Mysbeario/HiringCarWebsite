using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "6", 1100000m, "Kia Sorento", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "24", 1500000m, "Ford Tourneo", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "23", 1400000m, "Peugoet", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "22", 900000m, "Huyndai Kona", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "21", 600000m, "Vinfast Fadil", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "20", 1200000m, "Chevrolet Blazetrailer", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "19", 800000m, "Honda City TOP", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "18", 700000m, "Honda City", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "17", 2200000m, "Mescedes C250", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "25", 1300000m, "Mazda 6", (byte)4 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "16", 2000000m, "Mescedes C200", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "14", 1200000m, "Mazda CX5", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "13", 800000m, "Mazda 3", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "12", 900000m, "Toyota Corrola Altis", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "11", 700000m, "Innova", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "10", 1200000m, "Fortuner", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "9", 100000m, "Camry", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "8", 1600000m, "Sendona", (byte)8 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "7", 800000m, "Rondo", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "15", 2000000m, "Mescedes CLA", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { "26", 1100000m, "Honda Civic", (byte)5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "13");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "14");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "15");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "16");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "17");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "18");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "19");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "20");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "21");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "22");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "23");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "24");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "25");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "26");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: "9");
        }
    }
}
