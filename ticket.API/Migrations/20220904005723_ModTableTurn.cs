using Microsoft.EntityFrameworkCore.Migrations;

namespace ticket.API.Migrations
{
    public partial class ModTableTurn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Turns",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Turns",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Turns");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Turns");
        }
    }
}
