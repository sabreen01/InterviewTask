using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class applyseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2da474d-a3ed-4d9d-8721-90a17ef6a4d8", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a94188ea-e7e6-4359-bebc-a489a675fba8", 0, "5d0fc983-045b-4948-9c1c-e1ab4db1f9ca", "ad@hh.com", false, false, null, "AD@HH.COM", "AHMED", "AQAAAAIAAYagAAAAEFaxE07NGTqsxIggMwbEwq6c8d7xq0PECWWPgQgrIKXDWssvqxCSXrtBGCS/cQIIFQ==", null, false, "F4Y2Z6X5W5AWDWZ3J7B62XSNOOWJCIUB", false, "ahmed" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b2da474d-a3ed-4d9d-8721-90a17ef6a4d8", "a94188ea-e7e6-4359-bebc-a489a675fba8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b2da474d-a3ed-4d9d-8721-90a17ef6a4d8", "a94188ea-e7e6-4359-bebc-a489a675fba8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2da474d-a3ed-4d9d-8721-90a17ef6a4d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a94188ea-e7e6-4359-bebc-a489a675fba8");
        }
    }
}
