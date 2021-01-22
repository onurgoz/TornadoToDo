using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TornadoToDo.DataAccess.Migrations
{
    public partial class updateCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cards",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TaskDate",
                table: "Cards",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "TaskDate",
                table: "Cards");
        }
    }
}
