using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Blog_Likes_int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ed9cd5c-fd1b-438d-af70-f85565b94b6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b37a474-79dc-4f09-97a1-8bf011891d3b");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "096e9a86-b6d6-4cc8-9228-886589d7d0bc", "e20ff83f-d431-4c1b-b299-dae644f2221e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee48e356-4b07-4e2a-affe-7a98ffb7a652", "6acea394-6fc8-4a11-b7ff-863b008f19a8", "Writer", "WRITER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096e9a86-b6d6-4cc8-9228-886589d7d0bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee48e356-4b07-4e2a-affe-7a98ffb7a652");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Blogs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b37a474-79dc-4f09-97a1-8bf011891d3b", "614f81df-f614-413e-acf0-0afadf7420d7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ed9cd5c-fd1b-438d-af70-f85565b94b6e", "c5282501-2465-446c-8648-ce3a8837134f", "Writer", "WRITER" });
        }
    }
}
