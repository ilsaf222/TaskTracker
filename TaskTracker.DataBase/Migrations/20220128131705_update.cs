using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.DataBase.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "TaskName",
                table: "Objectives",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Objectives",
                newName: "TaskName");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Projects",
                type: "integer",
                nullable: true);
        }
    }
}
