using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class AddingBookData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookIndex",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookIndex",
                table: "Books");
        }
    }
}
