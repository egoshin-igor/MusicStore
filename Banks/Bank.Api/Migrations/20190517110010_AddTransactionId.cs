using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Bank.Api.Migrations
{
    public partial class AddTransactionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsHistory_Client_Email",
                table: "TransactionsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionsHistory",
                table: "TransactionsHistory");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TransactionsHistory",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "TransactionsHistory",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionsHistory",
                table: "TransactionsHistory",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsHistory_Email",
                table: "TransactionsHistory",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsHistory_Client_Email",
                table: "TransactionsHistory",
                column: "Email",
                principalTable: "Client",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsHistory_Client_Email",
                table: "TransactionsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionsHistory",
                table: "TransactionsHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionsHistory_Email",
                table: "TransactionsHistory");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "TransactionsHistory");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TransactionsHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionsHistory",
                table: "TransactionsHistory",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsHistory_Client_Email",
                table: "TransactionsHistory",
                column: "Email",
                principalTable: "Client",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
