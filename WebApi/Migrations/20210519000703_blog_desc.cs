using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class blog_desc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6202f42a-82fd-4ce3-93b5-abfb04ab26ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da5356ee-1f71-479a-9bb2-19cd249356f2");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Blogs",
                type: "character varying(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a484738e-f842-4639-bb8f-ba64ebebb913", "471b8465-02e7-402e-825d-01e94951f527", "Admin", "ADMIN" },
                    { "5cbbff63-be48-448c-b2dc-c77fba5ecea1", "1a349490-e8dd-4128-b2bd-efc0f98f893b", "Writer", "WRITER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cbbff63-be48-448c-b2dc-c77fba5ecea1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a484738e-f842-4639-bb8f-ba64ebebb913");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Blogs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6202f42a-82fd-4ce3-93b5-abfb04ab26ad", "da41671a-93d4-4786-838f-2aa70f5e6b7a", "Admin", "ADMIN" },
                    { "da5356ee-1f71-479a-9bb2-19cd249356f2", "fafd6748-50e5-4dd1-b0d5-f83971ff81d7", "Writer", "WRITER" }
                });
        }
    }
}
