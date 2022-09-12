using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class alltab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "allNewsPaper",
                columns: table => new
                {
                    Nid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    newspaperdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstpubdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    desc_info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allNewsPaper", x => x.Nid);
                });

            migrationBuilder.CreateTable(
                name: "Archaeology",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageurl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archaeology", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "theses",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thesisurl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pagesnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    desc_info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "issuance",
                columns: table => new
                {
                    Pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Issuancedate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuanceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllNewsPapersNid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issuance", x => x.Pid);
                    table.ForeignKey(
                        name: "FK_issuance_allNewsPaper_AllNewsPapersNid",
                        column: x => x.AllNewsPapersNid,
                        principalTable: "allNewsPaper",
                        principalColumn: "Nid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "issuancepapers",
                columns: table => new
                {
                    ppid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageurl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuancePid = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issuancepapers", x => x.ppid);
                    table.ForeignKey(
                        name: "FK_issuancepapers_issuance_IssuancePid",
                        column: x => x.IssuancePid,
                        principalTable: "issuance",
                        principalColumn: "Pid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pageTitles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ppid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issuancepaperppid = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pageTitles", x => x.id);
                    table.ForeignKey(
                        name: "FK_pageTitles_issuancepapers_Issuancepaperppid",
                        column: x => x.Issuancepaperppid,
                        principalTable: "issuancepapers",
                        principalColumn: "ppid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_issuance_AllNewsPapersNid",
                table: "issuance",
                column: "AllNewsPapersNid");

            migrationBuilder.CreateIndex(
                name: "IX_issuancepapers_IssuancePid",
                table: "issuancepapers",
                column: "IssuancePid");

            migrationBuilder.CreateIndex(
                name: "IX_pageTitles_Issuancepaperppid",
                table: "pageTitles",
                column: "Issuancepaperppid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archaeology");

            migrationBuilder.DropTable(
                name: "pageTitles");

            migrationBuilder.DropTable(
                name: "theses");

            migrationBuilder.DropTable(
                name: "issuancepapers");

            migrationBuilder.DropTable(
                name: "issuance");

            migrationBuilder.DropTable(
                name: "allNewsPaper");
        }
    }
}
