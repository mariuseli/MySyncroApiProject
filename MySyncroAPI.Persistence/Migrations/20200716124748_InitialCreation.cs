using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySyncroAPI.Persistence.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ContactDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyContacts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyContacts");
        }
    }
}
