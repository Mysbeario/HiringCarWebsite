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
                values: new object[] { 1, 700000m, "Ford EcoSport", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 24, 1500000m, "Ford Tourneo", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 23, 1400000m, "Peugoet", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 22, 900000m, "Huyndai Kona", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 21, 600000m, "Vinfast Fadil", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 20, 1200000m, "Chevrolet Blazetrailer", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 19, 800000m, "Honda City TOP", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 18, 700000m, "Honda City", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 17, 2200000m, "Mescedes C250", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 16, 2000000m, "Mescedes C200", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 15, 2000000m, "Mescedes CLA", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 14, 1200000m, "Mazda CX5", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 13, 800000m, "Mazda 3", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 12, 900000m, "Toyota Corrola Altis", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 11, 700000m, "Innova", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 10, 1200000m, "Fortuner", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 9, 100000m, "Camry", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 8, 1600000m, "Sendona", (byte)8 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 7, 800000m, "Rondo", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 6, 1100000m, "Kia Sorento", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 5, 700000m, "Kia Cerato", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 4, 500000m, "Kia Morning", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 3, 700000m, "Ford Fiesta", (byte)5 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 2, 1500000m, "Ford Everest", (byte)7 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 25, 1300000m, "Mazda 6", (byte)4 });

            migrationBuilder.InsertData(
                table: "CarType",
                columns: new[] { "Id", "Cost", "Name", "Seat" },
                values: new object[] { 26, 1100000m, "Honda Civic", (byte)5 });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 22, 2, "Silver", "51F-90254" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 1, 19, "White", "51G-23560" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 29, 18, "White", "51G-74963" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 18, 18, "White", "51A-48815" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 9, 18, "White", "51G-75835" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 32, 17, "White", "51G-32014" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 23, 16, "White", "51G-XX404" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 4, 16, "White", "51G-65404" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 31, 15, "White", "51G-22542" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 8, 15, "White", "51G-63428" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 24, 14, "White", "51G-57912" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 19, 14, "Red", "51G-58430" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 3, 14, "White", "51G-74141" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 16, 13, "Dark Blue", "51G-89975" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 15, 13, "White", "51F-56476" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 11, 13, "White", "51G-32986" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 6, 13, "White", "51G-22986" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 30, 12, "White", "51G-33591" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 2, 12, "Silver", "51G-69186" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 27, 11, "Silver", "51G-35204" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 14, 11, "Silver", "51G-99604" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 13, 11, "Black", "51G-37128" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 10, 10, "White", "94A-37715" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 5, 10, "White", "94A-19715" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 7, 9, "Silver", "51G-23186" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 20, 6, "White", "51G-22488" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 28, 5, "White", "51G-12592" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 21, 5, "White", "51F-12136" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 26, 4, "Red", "51F-56959" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 25, 2, "Black", "51H-23163" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 12, 21, "White", "61A-76150" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "NumberPlate" },
                values: new object[] { 17, 22, "White", "51G-21640" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CarType",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
