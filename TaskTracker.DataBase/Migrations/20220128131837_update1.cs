using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.DataBase.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Objectives_ObjectiveId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectiveId",
                table: "Projects",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Objectives_ObjectiveId",
                table: "Projects",
                column: "ObjectiveId",
                principalTable: "Objectives",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Objectives_ObjectiveId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ObjectiveId",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Objectives_ObjectiveId",
                table: "Projects",
                column: "ObjectiveId",
                principalTable: "Objectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
