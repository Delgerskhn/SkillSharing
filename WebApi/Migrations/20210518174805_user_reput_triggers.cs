using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class user_reput_triggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               sql: @"
               create or replace function update_user_reputation() 
	                returns trigger
	                language plpgsql
	                as
                $$
                begin
	                update ""AspNetUsers"" 

                        set ""Reputation"" = ""Reputation"" + 1,
                        ""WithdrawReputation"" = ""WithdrawReputation"" + 1

                        where ""Id"" = (select ""UserPk"" from ""Blogs"" where ""Pk"" = NEW.""BlogPk"");
                            update ""Blogs"" set ""Likes"" = ""Likes"" + 1 where ""Pk"" = NEW.""BlogPk"";
                            return new;
                            end;
                $$;
                    create trigger UserReput_Add_Like
                        after insert
                        on public.""Likes""
	                for each row
                    execute procedure update_user_reputation();

                ",
               suppressTransaction: true);

            migrationBuilder.Sql(
               sql: @"
                create or replace function update_user_reputation_on_comment() 
	                returns trigger
	                language plpgsql
	                as
                $$
                begin
	                update ""AspNetUsers"" 

                        set ""Reputation"" = ""Reputation"" + 2,
                        ""WithdrawReputation"" = ""WithdrawReputation"" + 2

                        where ""Id"" = (select ""UserPk"" from ""Blogs"" where ""Pk"" = NEW.""BlogPk"");
                            return new;
                            end;
                $$;
                create trigger UserReput_Add_Comment
                    after insert
                    on public.""Comments""
	            for each row
                execute procedure update_user_reputation();
                ",
               suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               sql: @"
                drop trigger UserReput_Add_Comment on ""Comments"";
	            drop trigger ""UserReput_Add_Like"" on ""Likes"";
                ",
               suppressTransaction: true);
        }
    }
}
