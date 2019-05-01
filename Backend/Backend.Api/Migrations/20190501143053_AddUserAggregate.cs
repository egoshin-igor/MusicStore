using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Backend.Api.Migrations
{
    public partial class AddUserAggregate : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>( nullable: false ),
                    Role = table.Column<string>( nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_User", x => x.Email );
                } );

            migrationBuilder.CreateTable(
                name: "UserLoginToken",
                columns: table => new
                {
                    Email = table.Column<string>( nullable: false ),
                    Token = table.Column<string>( nullable: true ),
                    ExpiratedOnUtc = table.Column<DateTime>( nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_UserLoginToken", x => x.Email );
                    table.ForeignKey(
                        name: "FK_UserLoginToken_User_Email",
                        column: x => x.Email,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade );
                } );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "UserLoginToken" );

            migrationBuilder.DropTable(
                name: "User" );
        }
    }
}
