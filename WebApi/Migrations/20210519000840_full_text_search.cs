using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class full_text_search : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               sql: @"
                alter table ""Blogs"" add ""DocumentVectors"" tsvector;
                create index idx_fts_doc_vec on ""Blogs"" using gin(""DocumentVectors"");

                create or replace function update_blog_vectors() 
	                returns trigger
	                language plpgsql
	                as
                $$
                begin
	                update ""Blogs"" 
                        set ""DocumentVectors"" = (to_tsvector(""Title"") || to_tsvector(""Content"") || to_tsvector(""Description""))
                        where ""Pk"" = NEW.""Pk"";
                            return new;
                            end;
                $$;
                create trigger Update_Blog_Vectors
                    after insert
                    on public.""Blogs""
	            for each row
                execute procedure update_blog_vectors();

                CREATE OR REPLACE FUNCTION public.upd_blog_vectors(
                    blogPk int)
                    RETURNS int
                    LANGUAGE 'sql'

                    COST 100
                    VOLATILE 
                AS $BODY$
                update ""Blogs"" 
                set ""DocumentVectors"" = (to_tsvector(""Title"") || to_tsvector(""Content"") || to_tsvector(""Description""))
                where ""Pk"" = blogPk;
                select 1
                $BODY$;
                
                create or replace function Blogs_Sel_Query(search_query character varying)
	                returns setof ""Blogs""
                as
                $$

                    select * from ""Blogs"" where ""DocumentVectors"" @@ plainto_tsquery(search_query) and ""BlogStatusPk"" = 2;; 
                $$
                language sql;
            ",
               suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(
               sql: @"
                drop index idx_fts_doc_vec;
                drop trigger Update_Blog_Vectors on ""Blogs"";
                alter table ""Blogs"" drop ""DocumentVectors"" ;
                ",
               suppressTransaction: true);
        }
    }
}
