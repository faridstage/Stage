using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class AddingRolesAgainWithAnotherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(460)", maxLength: 460, nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "appUserRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(460)", maxLength: 460, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(460)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appUserRoles_appRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "appRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appUserRoles_RoleId",
                table: "appUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_appUserRoles_UserId",
                table: "appUserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appUserRoles");

            migrationBuilder.DropTable(
                name: "appRoles");
        }
    }
}
