using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class SeedImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Car",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgPath",
                value: "img_51G_23560");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgPath",
                value: "img_51G_69186");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgPath",
                value: "img_51G_74141");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgPath",
                value: "img_51G_65404");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgPath",
                value: "img_94A_19715");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImgPath",
                value: "img_51G_22986");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImgPath",
                value: "img_51G_23186");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImgPath",
                value: "img_51G_63428");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImgPath",
                value: "img_51G_75835");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImgPath",
                value: "img_94A_37715");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImgPath",
                value: "img_51G_32986");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImgPath",
                value: "img_61A_76150");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImgPath",
                value: "img_51G_37128");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImgPath",
                value: "img_51G_99604");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImgPath",
                value: "img_51F_56476");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImgPath",
                value: "img_51G_89975");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImgPath",
                value: "img_51G_21640");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImgPath",
                value: "img_51A_48815");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImgPath",
                value: "img_51G_58430");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImgPath",
                value: "img_51G_22488");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImgPath",
                value: "img_51F_12136");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImgPath",
                value: "img_51F_90254");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ImgPath", "NumberPlate" },
                values: new object[] { "img_51G_66404", "51G-66404" });

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImgPath",
                value: "img_51G_57912");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImgPath",
                value: "img_51H_23163");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 26,
                column: "ImgPath",
                value: "img_51F_56959");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 27,
                column: "ImgPath",
                value: "img_51G_35204");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImgPath",
                value: "img_51G_12592");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 29,
                column: "ImgPath",
                value: "img_51G_74963");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 30,
                column: "ImgPath",
                value: "img_51G_33591");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImgPath",
                value: "img_51G_22542");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImgPath",
                value: "img_51G_32014");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Car");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "Id",
                keyValue: 23,
                column: "NumberPlate",
                value: "51G-XX404");
        }
    }
}
