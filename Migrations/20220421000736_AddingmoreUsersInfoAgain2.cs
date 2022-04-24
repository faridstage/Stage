using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class AddingmoreUsersInfoAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nlanguage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "phone",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "work",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nlanguage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "birth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "city",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "work",
                table: "AspNetUsers");
        }
    }
}
