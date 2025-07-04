using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mediator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogAuthor",
                table: "BlogAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "BlogAuthor",
                newName: "BlogAuthors");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Blogs");

            migrationBuilder.RenameColumn(
                name: "Isactive",
                table: "BlogAuthors",
                newName: "IsActive");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogAuthors",
                table: "BlogAuthors",
                column: "AuthorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorID",
                table: "Blogs",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogAuthors_AuthorID",
                table: "Blogs",
                column: "AuthorID",
                principalTable: "BlogAuthors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogAuthors_AuthorID",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_AuthorID",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogAuthors",
                table: "BlogAuthors");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blog");

            migrationBuilder.RenameTable(
                name: "BlogAuthors",
                newName: "BlogAuthor");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "BlogAuthor",
                newName: "Isactive");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogAuthor",
                table: "BlogAuthor",
                column: "AuthorID");
        }
    }
}
