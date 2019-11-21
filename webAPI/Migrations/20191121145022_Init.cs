using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationPackages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    VacationPackageId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    ManagerId = table.Column<int>(nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    CompletedDateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_VacationPackages_VacationPackageId",
                        column: x => x.VacationPackageId,
                        principalTable: "VacationPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FullName", "IsDeleted", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "vasya@mail.ru", "Вася", false, "88005553535" },
                    { 2, "peterthefirst@gmail.com", "Петя", false, "9922623447" },
                    { 3, "galina177@yandex.ru", "Галя", false, "88005553535" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, "Manage", "Ment", new byte[] { 80, 76, 251, 33, 238, 104, 54, 101, 45, 144, 58, 134, 7, 180, 118, 220, 60, 38, 98, 199, 147, 71, 206, 201, 215, 102, 7, 182, 20, 138, 48, 134, 41, 183, 218, 28, 190, 190, 142, 102, 139, 99, 25, 7, 144, 73, 153, 22, 102, 125, 137, 224, 25, 129, 94, 92, 226, 31, 130, 24, 24, 97, 126, 126 }, new byte[] { 233, 15, 44, 255, 113, 247, 163, 224, 153, 223, 156, 116, 1, 248, 196, 193, 140, 250, 16, 1, 99, 60, 245, 95, 24, 180, 252, 122, 186, 18, 14, 106, 78, 48, 179, 0, 245, 44, 206, 21, 94, 90, 174, 200, 245, 159, 201, 107, 63, 89, 86, 66, 219, 200, 244, 215, 183, 162, 42, 109, 10, 87, 108, 93, 93, 232, 198, 115, 193, 46, 177, 160, 142, 54, 137, 60, 108, 165, 156, 63, 210, 224, 111, 255, 123, 27, 156, 100, 240, 137, 22, 181, 246, 20, 166, 220, 126, 237, 93, 13, 240, 97, 107, 27, 68, 50, 146, 255, 36, 121, 118, 145, 153, 210, 217, 192, 230, 145, 178, 125, 4, 43, 161, 243, 187, 26, 56, 141 }, "manager" });

            migrationBuilder.InsertData(
                table: "VacationPackages",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, false, "Турция, отель 5 звезд", 20000 },
                    { 2, false, "Альпы, отель 5 звезд", 300000 },
                    { 3, false, "Сочи, отель 2 звезды", 1000 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CompletedDateTime", "CreationDateTime", "CustomerId", "IsDeleted", "ManagerId", "Price", "VacationPackageId" },
                values: new object[] { 1, new DateTime(2019, 11, 21, 17, 50, 22, 62, DateTimeKind.Local).AddTicks(5296), new DateTime(2019, 11, 21, 17, 50, 22, 60, DateTimeKind.Local).AddTicks(3420), 1, false, 1, 500, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CompletedDateTime", "CreationDateTime", "CustomerId", "IsDeleted", "ManagerId", "Price", "VacationPackageId" },
                values: new object[] { 2, new DateTime(2019, 11, 21, 17, 50, 22, 62, DateTimeKind.Local).AddTicks(6389), new DateTime(2019, 11, 21, 17, 50, 22, 62, DateTimeKind.Local).AddTicks(6339), 2, false, 1, 600, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CompletedDateTime", "CreationDateTime", "CustomerId", "IsDeleted", "ManagerId", "Price", "VacationPackageId" },
                values: new object[] { 3, new DateTime(2019, 11, 21, 17, 50, 22, 62, DateTimeKind.Local).AddTicks(6404), new DateTime(2019, 11, 21, 17, 50, 22, 62, DateTimeKind.Local).AddTicks(6403), 3, false, 1, 700, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_Username",
                table: "Managers",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ManagerId",
                table: "Orders",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VacationPackageId",
                table: "Orders",
                column: "VacationPackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "VacationPackages");
        }
    }
}
