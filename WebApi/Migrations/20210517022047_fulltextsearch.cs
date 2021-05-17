using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class fulltextsearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b89ca2d9-9a15-45fd-a414-3bf65530a671");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffef4fc2-138f-4e40-959f-f6f9d25a736a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "baec6f7a-8974-4eca-bb46-8514634004d2", "65fa8b18-0516-46ef-a484-d334d356d60a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc8027f3-7fac-4231-8873-a1d013c00701", "0404ee01-fc9a-4d12-a816-78c2a6caddc7", "Writer", "WRITER" });


            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT CATALOG ftCatalog AS DEFAULT;",
                suppressTransaction: true);

            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON Blogs(Title, Content) KEY INDEX PK_Blogs;",
                suppressTransaction: true);

            migrationBuilder.Sql(
                sql: @"
                    SET ANSI_NULLS ON
                    GO
                    SET QUOTED_IDENTIFIER ON
                    GO
                    -- =============================================
                    -- Author:		<Author,,Name>
                    -- Create date: <Create Date,,>
                    -- Description:	<Description,,>
                    -- =============================================
                    CREATE PROCEDURE Blogs_SEL_FreeText
	                    -- Add the parameters for the stored procedure here
	                    @query nvarchar(200)
                    AS
                    BEGIN
	                    -- SET NOCOUNT ON added to prevent extra result sets from
	                    -- interfering with SELECT statements.
	                    SET NOCOUNT ON;
	                     select top 20 * from Blogs 
		                    where FreeText((Title, Content), @query)
		                    order by pk desc
                        -- Insert statements for procedure here
                    END
                    GO
                ",
                suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "baec6f7a-8974-4eca-bb46-8514634004d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc8027f3-7fac-4231-8873-a1d013c00701");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b89ca2d9-9a15-45fd-a414-3bf65530a671", "ef7ff5e4-4879-4cd8-aeeb-05e6b8549a42", "Admin", "ADMIN" });
            

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffef4fc2-138f-4e40-959f-f6f9d25a736a", "688c60e4-1f04-47d6-b004-7a41cb3328c9", "Writer", "WRITER" });
            migrationBuilder.Sql(
               sql: "drop fulltext index on Blogs",
               suppressTransaction: true);
            migrationBuilder.Sql(
               sql: "drop fulltext catalog ftCatalog",
               suppressTransaction: true);

            migrationBuilder.Sql(
                sql: "drop proc Blogs_SEL_FreeText;",
                suppressTransaction: true);
        }
    }
}
