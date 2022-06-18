using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class AddingForeignKeyToSaved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Saved",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saved_UserId",
                table: "Saved",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saved_AspNetUsers_UserId",
                table: "Saved",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saved_AspNetUsers_UserId",
                table: "Saved");

            migrationBuilder.DropIndex(
                name: "IX_Saved_UserId",
                table: "Saved");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Saved");
        }
    }
}
