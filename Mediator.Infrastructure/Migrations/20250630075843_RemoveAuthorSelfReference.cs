using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mediator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuthorSelfReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "BlogAuthor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogAuthor_AuthorID1",
                table: "BlogAuthor",
                column: "AuthorID1");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogAuthor_BlogAuthor_AuthorID1",
                table: "BlogAuthor",
                column: "AuthorID1",
                principalTable: "BlogAuthor",
                principalColumn: "AuthorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogAuthor_BlogAuthor_AuthorID1",
                table: "BlogAuthor");

            migrationBuilder.DropIndex(
                name: "IX_BlogAuthor_AuthorID1",
                table: "BlogAuthor");

            migrationBuilder.DropColumn(
                name: "AuthorID1",
                table: "BlogAuthor");
        }
    }
}
