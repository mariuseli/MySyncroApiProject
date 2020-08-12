using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySyncroAPI.Persistence.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SyncSessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RefId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    SessionName = table.Column<string>(nullable: true),
                    SessionItemsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RefId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ContactName = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactPhoneNumber = table.Column<string>(nullable: true),
                    ContactDescription = table.Column<string>(nullable: true),
                    MySyncSessionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyContacts_SyncSessions_MySyncSessionId",
                        column: x => x.MySyncSessionId,
                        principalTable: "SyncSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyContacts_MySyncSessionId",
                table: "MyContacts",
                column: "MySyncSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyContacts");

            migrationBuilder.DropTable(
                name: "SyncSessions");
        }
    }
}
