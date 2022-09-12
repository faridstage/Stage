using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class order3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "orderViewModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderViewModel_UserId",
                table: "orderViewModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderViewModel_AspNetUsers_UserId",
                table: "orderViewModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderViewModel_AspNetUsers_UserId",
                table: "orderViewModel");

            migrationBuilder.DropIndex(
                name: "IX_orderViewModel_UserId",
                table: "orderViewModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "orderViewModel");
        }
    }
}
