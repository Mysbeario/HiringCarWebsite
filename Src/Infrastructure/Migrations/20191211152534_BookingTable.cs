using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class BookingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Seat = table.Column<byte>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarTypeId = table.Column<int>(nullable: false),
                    NumberPlate = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    ImgPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_CarType_CarTypeId",
                        column: x => x.CarTypeId,
                        principalTable: "CarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    PickUpDate = table.Column<DateTime>(nullable: false),
                    DropOffDate = table.Column<DateTime>(nullable: false),
                    PickUpLocation = table.Column<string>(nullable: true),
                    DropOffLocation = table.Column<string>(nullable: true),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 22, 2, "Silver", "img_51F_90254", "51F-90254" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 1, 19, "White", "img_51G_23560", "51G-23560" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 29, 18, "White", "img_51G_74963", "51G-74963" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 18, 18, "White", "img_51A_48815", "51A-48815" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 9, 18, "White", "img_51G_75835", "51G-75835" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 32, 17, "White", "img_51G_32014", "51G-32014" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 23, 16, "White", "img_51G_66404", "51G-66404" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 4, 16, "White", "img_51G_65404", "51G-65404" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 31, 15, "White", "img_51G_22542", "51G-22542" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 8, 15, "White", "img_51G_63428", "51G-63428" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 24, 14, "White", "img_51G_57912", "51G-57912" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 19, 14, "Red", "img_51G_58430", "51G-58430" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 3, 14, "White", "img_51G_74141", "51G-74141" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 16, 13, "Dark Blue", "img_51G_89975", "51G-89975" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 15, 13, "White", "img_51F_56476", "51F-56476" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 11, 13, "White", "img_51G_32986", "51G-32986" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 6, 13, "White", "img_51G_22986", "51G-22986" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 30, 12, "White", "img_51G_33591", "51G-33591" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 2, 12, "Silver", "img_51G_69186", "51G-69186" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 27, 11, "Silver", "img_51G_35204", "51G-35204" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 14, 11, "Silver", "img_51G_99604", "51G-99604" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 13, 11, "Black", "img_51G_37128", "51G-37128" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 10, 10, "White", "img_94A_37715", "94A-37715" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 5, 10, "White", "img_94A_19715", "94A-19715" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 7, 9, "Silver", "img_51G_23186", "51G-23186" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 20, 6, "White", "img_51G_22488", "51G-22488" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 28, 5, "White", "img_51G_12592", "51G-12592" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 21, 5, "White", "img_51F_12136", "51F-12136" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 26, 4, "Red", "img_51F_56959", "51F-56959" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 25, 2, "Black", "img_51H_23163", "51H-23163" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 12, 21, "White", "img_61A_76150", "61A-76150" });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "CarTypeId", "Color", "ImgPath", "NumberPlate" },
                values: new object[] { 17, 22, "White", "img_51G_21640", "51G-21640" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CarId",
                table: "Booking",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarTypeId",
                table: "Car",
                column: "CarTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CarType");
        }
    }
}
