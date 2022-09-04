using Microsoft.EntityFrameworkCore.Migrations;

namespace ticket.API.Migrations
{
    public partial class ModTableTurnIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Turns_ShiftNumber",
                table: "Turns");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_ShiftNumber",
                table: "Turns",
                column: "ShiftNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Turns_ShiftNumber",
                table: "Turns");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_ShiftNumber",
                table: "Turns",
                column: "ShiftNumber",
                unique: true);
        }
    }
}
