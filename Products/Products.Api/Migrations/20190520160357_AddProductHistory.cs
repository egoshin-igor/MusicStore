using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Products.Api.Migrations
{
    public partial class AddProductHistory : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "ProductHistory",
                columns: table => new
                {
                    ProductHistoryId = table.Column<int>( nullable: false )
                        .Annotation( "SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn ),
                    Email = table.Column<string>( nullable: true ),
                    ProductName = table.Column<string>( nullable: true ),
                    Qunatity = table.Column<string>( nullable: true ),
                    PricePerItem = table.Column<decimal>( nullable: false ),
                    OccuredOnUtc = table.Column<DateTime>( nullable: false ),
                    TransactionId = table.Column<string>( nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_ProductHistory", x => x.ProductHistoryId );
                } );

            migrationBuilder.CreateIndex(
                name: "IX_ProductHistory_Email_TransactionId",
                table: "ProductHistory",
                columns: new[] { "Email", "TransactionId" } );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "ProductHistory" );
        }
    }
}
