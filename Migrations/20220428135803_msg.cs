using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class msg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactmsgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactmsgs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contactmsgs");
        }
    }
}
