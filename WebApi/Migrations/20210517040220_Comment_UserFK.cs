using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Comment_UserFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "baec6f7a-8974-4eca-bb46-8514634004d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc8027f3-7fac-4231-8873-a1d013c00701");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Comments",
                newName: "UserPk");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                newName: "IX_Comments_UserPk");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82372f73-0a2f-41f8-84e2-389bd9d00c0d", "27302301-6705-46eb-89c9-e58a0d962beb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22a00862-cf14-4af8-9ff8-10ceef89c011", "dc02a457-6985-48ef-8e6d-b7f9808c1433", "Writer", "WRITER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserPk",
                table: "Comments",
                column: "UserPk",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserPk",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22a00862-cf14-4af8-9ff8-10ceef89c011");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82372f73-0a2f-41f8-84e2-389bd9d00c0d");

            migrationBuilder.RenameColumn(
                name: "UserPk",
                table: "Comments",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserPk",
                table: "Comments",
                newName: "IX_Comments_AppUserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "baec6f7a-8974-4eca-bb46-8514634004d2", "65fa8b18-0516-46ef-a484-d334d356d60a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc8027f3-7fac-4231-8873-a1d013c00701", "0404ee01-fc9a-4d12-a816-78c2a6caddc7", "Writer", "WRITER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
