using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class blog_userpk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserId",
                table: "Blogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "434e7a9e-19ab-4f2f-bb32-8440b98f50f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc1a396e-fab2-4438-aec5-012a273fad1c");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Blogs",
                newName: "UserPk");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_AppUserId",
                table: "Blogs",
                newName: "IX_Blogs_UserPk");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e01f3e4-dfb7-4563-8011-77b9353a6673", "8b3951e7-9062-47ab-b6ba-c2b2a1c88aa6", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0eeee32-6a16-4049-8b55-ceab4518ece6", "05cb933d-1713-4a07-b421-597ae025793e", "Writer", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_UserPk",
                table: "Blogs",
                column: "UserPk",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_UserPk",
                table: "Blogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e01f3e4-dfb7-4563-8011-77b9353a6673");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0eeee32-6a16-4049-8b55-ceab4518ece6");

            migrationBuilder.RenameColumn(
                name: "UserPk",
                table: "Blogs",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_UserPk",
                table: "Blogs",
                newName: "IX_Blogs_AppUserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "434e7a9e-19ab-4f2f-bb32-8440b98f50f0", "4bdcebf2-2571-47d8-ae15-d509fa024509", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc1a396e-fab2-4438-aec5-012a273fad1c", "a5096504-a402-4515-9c63-dbdf526ed630", "Writer", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserId",
                table: "Blogs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
