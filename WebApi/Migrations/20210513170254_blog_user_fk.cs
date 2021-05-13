using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class blog_user_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52838fd0-313d-4165-ba49-a86eec5ce85c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a42ab7f9-067a-4260-96ee-9f0bee333d1c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "434e7a9e-19ab-4f2f-bb32-8440b98f50f0", "4bdcebf2-2571-47d8-ae15-d509fa024509", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc1a396e-fab2-4438-aec5-012a273fad1c", "a5096504-a402-4515-9c63-dbdf526ed630", "Writer", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "434e7a9e-19ab-4f2f-bb32-8440b98f50f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc1a396e-fab2-4438-aec5-012a273fad1c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a42ab7f9-067a-4260-96ee-9f0bee333d1c", "d3d21eb4-e996-4737-9aa0-93d37c5178f3", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52838fd0-313d-4165-ba49-a86eec5ce85c", "3d7fef67-5c8d-4d30-ac9c-cfc6415dfc06", "Writer", null });
        }
    }
}
