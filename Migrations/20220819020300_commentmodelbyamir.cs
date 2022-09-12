using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class commentmodelbyamir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "BookComments");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BookComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookComments_UserId",
                table: "BookComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookComments_AspNetUsers_UserId",
                table: "BookComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookComments_AspNetUsers_UserId",
                table: "BookComments");

            migrationBuilder.DropIndex(
                name: "IX_BookComments_UserId",
                table: "BookComments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookComments");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "BookComments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
