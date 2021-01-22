using Microsoft.EntityFrameworkCore.Migrations;

namespace TornadoToDo.DataAccess.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Cards",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Cards",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Boards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Boards_AppUserId",
                table: "Boards",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_AppUsers_AppUserId",
                table: "Boards",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_AppUsers_AppUserId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_AppUserId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Boards");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Cards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Cards",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
