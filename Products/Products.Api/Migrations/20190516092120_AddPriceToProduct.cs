using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Products.Api.Migrations
{
    public partial class AddPriceToProduct : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                nullable: false,
                defaultValue: 0m );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product" );
        }
    }
}
