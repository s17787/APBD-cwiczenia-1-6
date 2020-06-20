using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolos2_Piotr_Tryfon_APBD.Migrations
{
    public partial class RestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    IdEvent = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.IdEvent);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EventOrganiser_Event_IdEvent",
                table: "EventOrganiser",
                column: "IdEvent",
                principalTable: "Event",
                principalColumn: "IdEvent",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventOrganiser_Event_IdEvent",
                table: "EventOrganiser");

            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
