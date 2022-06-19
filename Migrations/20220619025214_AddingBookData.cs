using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class AddingBookData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookIntro",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookIntro",
                table: "Books");
        }
    }
}
