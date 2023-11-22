using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avhrm.Identity.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb383b16-dfc9-487f-b4bb-053eab408d8e", null, "Admin", "کاربر مدیر" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentId", "PasswordHash", "PersianName", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6f236e65-88a2-4530-aa66-b1fa9eef0c88", 0, "cc86f6f8-624e-488e-a778-dbff321869d7", null, false, false, null, null, "admin", null, "f2f619dff944a68d2f5cb536c451a89d8adfeb8f673e37ae6558c7ec4a366f60", "مدیر سیستم", null, false, "b0dad920-f536-4088-83b3-cd2072cc60b4", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cb383b16-dfc9-487f-b4bb-053eab408d8e", "6f236e65-88a2-4530-aa66-b1fa9eef0c88" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cb383b16-dfc9-487f-b4bb-053eab408d8e", "6f236e65-88a2-4530-aa66-b1fa9eef0c88" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb383b16-dfc9-487f-b4bb-053eab408d8e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f236e65-88a2-4530-aa66-b1fa9eef0c88");
        }
    }
}
