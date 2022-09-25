using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ticket.API.Migrations
{
    public partial class TurnModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Turns");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Turns");

            migrationBuilder.AddColumn<DateTime>(
                name: "AttentionDate",
                table: "Turns",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpeditionDate",
                table: "Turns",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Stand",
                table: "Turns",
                maxLength: 5,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttentionDate",
                table: "Turns");

            migrationBuilder.DropColumn(
                name: "ExpeditionDate",
                table: "Turns");

            migrationBuilder.DropColumn(
                name: "Stand",
                table: "Turns");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Turns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Turns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
