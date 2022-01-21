using Microsoft.EntityFrameworkCore.Migrations;

namespace my_books.Migrations
{
    public partial class ModifiedAuthorBooksDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Authors_BooksId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Books_AuthorsId",
                table: "AuthorBooks");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Authors_AuthorsId",
                table: "AuthorBooks",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Books_BooksId",
                table: "AuthorBooks",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Authors_AuthorsId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Books_BooksId",
                table: "AuthorBooks");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Authors_BooksId",
                table: "AuthorBooks",
                column: "BooksId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Books_AuthorsId",
                table: "AuthorBooks",
                column: "AuthorsId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
