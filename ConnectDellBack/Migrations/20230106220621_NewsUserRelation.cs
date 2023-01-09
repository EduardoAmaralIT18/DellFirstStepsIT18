using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectDellBack.Migrations
{
    /// <inheritdoc />
    public partial class NewsUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "authorid",
                table: "news",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_news_authorid",
                table: "news",
                column: "authorid");

            migrationBuilder.AddForeignKey(
                name: "FK_news_users_authorid",
                table: "news",
                column: "authorid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_users_authorid",
                table: "news");

            migrationBuilder.DropIndex(
                name: "IX_news_authorid",
                table: "news");

            migrationBuilder.DropColumn(
                name: "authorid",
                table: "news");
        }
    }
}
