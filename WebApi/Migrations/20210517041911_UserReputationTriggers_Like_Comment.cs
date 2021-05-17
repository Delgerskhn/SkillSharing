using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class UserReputationTriggers_Like_Comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22a00862-cf14-4af8-9ff8-10ceef89c011");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82372f73-0a2f-41f8-84e2-389bd9d00c0d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b37a474-79dc-4f09-97a1-8bf011891d3b", "614f81df-f614-413e-acf0-0afadf7420d7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ed9cd5c-fd1b-438d-af70-f85565b94b6e", "c5282501-2465-446c-8648-ce3a8837134f", "Writer", "WRITER" });

            migrationBuilder.Sql(
               sql: @"
                      create trigger UserReput_Add_Like
                      on Likes
                      after insert 
                      as 
                      begin 
	                    declare @UpdateUserPk nvarchar(50) = (select UserPk from Blogs where Pk = (select top 1 BlogPk from inserted));
	                    update AspNetUsers 
		                    set Reputation = Reputation + 1,
		                    WithdrawReputation = WithdrawReputation + 1
		                    where Id = @UpdateUserPk;
                        update Blogs set Likes = Likes+1 where Pk = (select top 1 BlogPk from inserted);
                      end
                      go
                      create trigger UserReput_Add_Comment
                      on Comments
                      after insert 
                      as 
                      begin 
	                    declare @UpdateUserPk nvarchar(50) = (select UserPk from Blogs where Pk = (select top 1 BlogPk from inserted));
	                    update AspNetUsers 
		                    set Reputation = Reputation + 2,
		                    WithdrawReputation = WithdrawReputation + 2
		                    where Id = @UpdateUserPk
                      end
                      go
                ",
               suppressTransaction: true);
            


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ed9cd5c-fd1b-438d-af70-f85565b94b6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b37a474-79dc-4f09-97a1-8bf011891d3b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82372f73-0a2f-41f8-84e2-389bd9d00c0d", "27302301-6705-46eb-89c9-e58a0d962beb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22a00862-cf14-4af8-9ff8-10ceef89c011", "dc02a457-6985-48ef-8e6d-b7f9808c1433", "Writer", "WRITER" });
            migrationBuilder.Sql(
               sql: @"
                Drop trigger UserReput_Add_Like;
                Drop trigger UserReput_Add_Comment;
                go;
                ",
               suppressTransaction: true);
        }
    }
}
