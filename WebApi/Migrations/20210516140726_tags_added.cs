using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class tags_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88a7427e-2e56-4ad0-b52e-834c9b1b1fb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1459324-426c-4b08-b04c-42b9183c2320");

            migrationBuilder.AddColumn<int>(
                name: "BlogPk",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59338743-7a88-4ba1-9721-1d737d835c8a", "86b1061e-65c4-4b50-8ed0-33b81d2bfae4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed382e1b-60d9-406a-b19c-4227f1976f26", "fb0692b2-5b67-4e92-a200-3e6cb4517471", "Writer", "WRITER" });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogPk",
                table: "Tags",
                column: "BlogPk");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Blogs_BlogPk",
                table: "Tags",
                column: "BlogPk",
                principalTable: "Blogs",
                principalColumn: "Pk",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Blogs_BlogPk",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_BlogPk",
                table: "Tags");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59338743-7a88-4ba1-9721-1d737d835c8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed382e1b-60d9-406a-b19c-4227f1976f26");

            migrationBuilder.DropColumn(
                name: "BlogPk",
                table: "Tags");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1459324-426c-4b08-b04c-42b9183c2320", "0f4bd497-5d37-497e-a979-046697b56a9b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88a7427e-2e56-4ad0-b52e-834c9b1b1fb1", "2543d174-9e05-43ab-b88a-717eb34a1fe8", "Writer", "WRITER" });
        }
    }
}
