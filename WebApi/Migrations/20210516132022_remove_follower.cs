using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class remove_follower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_AppUserId",
                table: "Likes");

            migrationBuilder.DropTable(
                name: "Followers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "299ec89b-206c-4c3a-b07b-d7bb14ba9199");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6951e407-0b9a-4787-b974-d8a1e1af0578");

            migrationBuilder.DropColumn(
                name: "Followers",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Likes",
                newName: "UserPk");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_AppUserId",
                table: "Likes",
                newName: "IX_Likes_UserPk");

            migrationBuilder.AddColumn<int>(
                name: "Reputation",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WithdrawReputation",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1459324-426c-4b08-b04c-42b9183c2320", "0f4bd497-5d37-497e-a979-046697b56a9b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88a7427e-2e56-4ad0-b52e-834c9b1b1fb1", "2543d174-9e05-43ab-b88a-717eb34a1fe8", "Writer", "WRITER" });

            migrationBuilder.InsertData(
                table: "BlogStatuses",
                columns: new[] { "Pk", "Name" },
                values: new object[] { 4, "Draft" });

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UserPk",
                table: "Likes",
                column: "UserPk",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UserPk",
                table: "Likes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88a7427e-2e56-4ad0-b52e-834c9b1b1fb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1459324-426c-4b08-b04c-42b9183c2320");

            migrationBuilder.DeleteData(
                table: "BlogStatuses",
                keyColumn: "Pk",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Reputation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WithdrawReputation",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserPk",
                table: "Likes",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserPk",
                table: "Likes",
                newName: "IX_Likes_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "Followers",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Followers",
                columns: table => new
                {
                    Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FollowerUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => x.Pk);
                    table.ForeignKey(
                        name: "FK_Followers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Followers_AspNetUsers_FollowerUserId",
                        column: x => x.FollowerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "299ec89b-206c-4c3a-b07b-d7bb14ba9199", "5e9093c0-640e-4599-83f0-aeff59fe234a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6951e407-0b9a-4787-b974-d8a1e1af0578", "bcd0f731-92cc-4c77-9923-d783affcd4a6", "Writer", "WRITER" });

            migrationBuilder.CreateIndex(
                name: "IX_Followers_AppUserId",
                table: "Followers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FollowerUserId",
                table: "Followers",
                column: "FollowerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_AppUserId",
                table: "Likes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
