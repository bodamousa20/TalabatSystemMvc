using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TalabatSmartVillage.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginDto");

            migrationBuilder.DropTable(
                name: "RegisterDto");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "A78adjdnmjj5214-03945fv%43mf", "A78adjdnmjj5214-03945fv%43mf", "ADMIN", "ADMIN" },
                    { "bkdd8ad52mjj5214-03945fv%43ds", "bkdd8ad52mjj5214-03945fv%43ds", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "postalcode" },
                values: new object[] { "adminsIdFakerIdes125d$2$@E@23", 0, "Admin Address", "ae56e2eb-a436-4980-adf5-14e3ec424a83", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKCc38T78doP4i8xDcHSarN9K8s9boaQ/tqiUNFdI+vO+jTenMkuJmuCCfNgnQP0NQ==", null, false, "ff917ecc-c7f6-446a-a286-475b554d5fc0", false, "admin@gmail.com", 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "A78adjdnmjj5214-03945fv%43mf", "adminsIdFakerIdes125d$2$@E@23" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bkdd8ad52mjj5214-03945fv%43ds");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "A78adjdnmjj5214-03945fv%43mf", "adminsIdFakerIdes125d$2$@E@23" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A78adjdnmjj5214-03945fv%43mf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminsIdFakerIdes125d$2$@E@23");

            migrationBuilder.CreateTable(
                name: "LoginDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RegisterDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    postalCode = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterDto", x => x.id);
                });
        }
    }
}
