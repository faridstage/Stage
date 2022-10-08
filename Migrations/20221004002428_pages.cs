using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class pages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "magazinepages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pageNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    magazincopysId = table.Column<int>(type: "int", nullable: false),
                    page = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_magazinepages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_magazinepages_magazincopys_magazincopysId",
                        column: x => x.magazincopysId,
                        principalTable: "magazincopys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_magazinepages_magazincopysId",
                table: "magazinepages",
                column: "magazincopysId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "magazinepages");
        }
    }
}
