using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Bank.Api.Migrations
{
    public partial class AddOwnerClient : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.InsertData(
                "Client",
                new[] { "Email", "Balance" },
                new object[] { "igor.egoshin@mail.ru", 1000d }
            );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {

        }
    }
}
