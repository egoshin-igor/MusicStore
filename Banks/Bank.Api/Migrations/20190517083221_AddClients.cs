using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Bank.Api.Migrations
{
    public partial class AddClients : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Email = table.Column<string>( nullable: false ),
                    Balance = table.Column<decimal>( nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Client", x => x.Email );
                } );

            migrationBuilder.CreateTable(
                name: "TransactionsHistory",
                columns: table => new
                {
                    Email = table.Column<string>( nullable: false ),
                    IsSuccess = table.Column<bool>( nullable: false ),
                    Type = table.Column<int>( nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_TransactionsHistory", x => x.Email );
                    table.ForeignKey(
                        name: "FK_TransactionsHistory_Client_Email",
                        column: x => x.Email,
                        principalTable: "Client",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade );
                } );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "TransactionsHistory" );

            migrationBuilder.DropTable(
                name: "Client" );
        }
    }
}
