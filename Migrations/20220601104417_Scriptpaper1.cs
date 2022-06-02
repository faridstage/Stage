using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class Scriptpaper1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scriptpaper",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scriptname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptdiscription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptlang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptdiscovored = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptdiscovoreddate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptdiscovoredpalce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptwriterby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scripttopic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptcategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptpalcestore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptimage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scripturl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    scriptnote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scriptpaper", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scriptpaper");
        }
    }
}
