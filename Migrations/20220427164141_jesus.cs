using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stage_Books.Migrations
{
    public partial class jesus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nlanguage",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "birth",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "phone",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "work",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nlanguage",
                table: "users");

            migrationBuilder.DropColumn(
                name: "birth",
                table: "users");

            migrationBuilder.DropColumn(
                name: "city",
                table: "users");

            migrationBuilder.DropColumn(
                name: "country",
                table: "users");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "users");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "users");

            migrationBuilder.DropColumn(
                name: "work",
                table: "users");
        }
    }
}
