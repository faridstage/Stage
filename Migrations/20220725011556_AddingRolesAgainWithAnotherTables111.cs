using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class AddingRolesAgainWithAnotherTables111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userRoleNews",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", maxLength: 460, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(460)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRoleNews", x => x.id);
                    table.ForeignKey(
                        name: "FK_userRoleNews_appRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "appRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userRoleNews_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userRoleNews_RoleId",
                table: "userRoleNews",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_userRoleNews_UserId",
                table: "userRoleNews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userRoleNews");
        }
    }
}
