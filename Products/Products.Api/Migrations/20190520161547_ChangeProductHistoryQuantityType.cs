using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Products.Api.Migrations
{
    public partial class ChangeProductHistoryQuantityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Qunatity",
                table: "ProductHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Qunatity",
                table: "ProductHistory",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
