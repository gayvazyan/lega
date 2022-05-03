using Microsoft.EntityFrameworkCore.Migrations;

namespace lega.Core.Migrations
{
    public partial class _152 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "PricingDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceValue",
                table: "PricingDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceValueEn",
                table: "PricingDb",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceValueRu",
                table: "PricingDb",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "PricingDb");

            migrationBuilder.DropColumn(
                name: "PriceValue",
                table: "PricingDb");

            migrationBuilder.DropColumn(
                name: "PriceValueEn",
                table: "PricingDb");

            migrationBuilder.DropColumn(
                name: "PriceValueRu",
                table: "PricingDb");
        }
    }
}
