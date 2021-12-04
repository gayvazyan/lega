using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lega.Core.Migrations
{
    public partial class news : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "NewsDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorEn",
                table: "NewsDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Context",
                table: "NewsDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContextEn",
                table: "NewsDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "NewsDb",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "NewsDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "NewsDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "NewsDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "NewsDb",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "NewsDb");

            migrationBuilder.DropColumn(
                name: "AuthorEn",
                table: "NewsDb");

            migrationBuilder.DropColumn(
                name: "Context",
                table: "NewsDb");

            migrationBuilder.DropColumn(
                name: "ContextEn",
                table: "NewsDb");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "NewsDb");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "NewsDb");

            migrationBuilder.DropColumn(
                name: "State",
                table: "NewsDb");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "NewsDb");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "NewsDb");
        }
    }
}
