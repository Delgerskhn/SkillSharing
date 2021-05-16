using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class tags_blogs_many_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Blogs_BlogPk",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "TagBlogs");

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

            migrationBuilder.CreateTable(
                name: "BlogTag",
                columns: table => new
                {
                    BlogsPk = table.Column<int>(type: "int", nullable: false),
                    TagsPk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTag", x => new { x.BlogsPk, x.TagsPk });
                    table.ForeignKey(
                        name: "FK_BlogTag_Blogs_BlogsPk",
                        column: x => x.BlogsPk,
                        principalTable: "Blogs",
                        principalColumn: "Pk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTag_Tags_TagsPk",
                        column: x => x.TagsPk,
                        principalTable: "Tags",
                        principalColumn: "Pk",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b89ca2d9-9a15-45fd-a414-3bf65530a671", "ef7ff5e4-4879-4cd8-aeeb-05e6b8549a42", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffef4fc2-138f-4e40-959f-f6f9d25a736a", "688c60e4-1f04-47d6-b004-7a41cb3328c9", "Writer", "WRITER" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_TagsPk",
                table: "BlogTag",
                column: "TagsPk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTag");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b89ca2d9-9a15-45fd-a414-3bf65530a671");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffef4fc2-138f-4e40-959f-f6f9d25a736a");

            migrationBuilder.AddColumn<int>(
                name: "BlogPk",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TagBlogs",
                columns: table => new
                {
                    BlogPk = table.Column<int>(type: "int", nullable: true),
                    TagPk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TagBlogs_Blogs_BlogPk",
                        column: x => x.BlogPk,
                        principalTable: "Blogs",
                        principalColumn: "Pk",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TagBlogs_Tags_TagPk",
                        column: x => x.TagPk,
                        principalTable: "Tags",
                        principalColumn: "Pk",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TagBlogs_BlogPk",
                table: "TagBlogs",
                column: "BlogPk");

            migrationBuilder.CreateIndex(
                name: "IX_TagBlogs_TagPk",
                table: "TagBlogs",
                column: "TagPk");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Blogs_BlogPk",
                table: "Tags",
                column: "BlogPk",
                principalTable: "Blogs",
                principalColumn: "Pk",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
