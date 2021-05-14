using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class appuser_followers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e01f3e4-dfb7-4563-8011-77b9353a6673");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0eeee32-6a16-4049-8b55-ceab4518ece6");

            migrationBuilder.AddColumn<int>(
                name: "Followers",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f880629a-e8a0-4ef5-b8c6-d96a282a92a9", "eeb46a10-ab59-490a-83bb-18db77051329", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c2cfd20c-a652-467f-825f-4ff2268dcd42", "992a6285-82b6-4ed7-8102-b263d42f6908", "Writer", "WRITER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2cfd20c-a652-467f-825f-4ff2268dcd42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f880629a-e8a0-4ef5-b8c6-d96a282a92a9");

            migrationBuilder.DropColumn(
                name: "Followers",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e01f3e4-dfb7-4563-8011-77b9353a6673", "8b3951e7-9062-47ab-b6ba-c2b2a1c88aa6", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0eeee32-6a16-4049-8b55-ceab4518ece6", "05cb933d-1713-4a07-b421-597ae025793e", "Writer", null });
        }
    }
}
