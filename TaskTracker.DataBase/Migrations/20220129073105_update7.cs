using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.DataBase.Migrations
{
    public partial class update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objectives_Projects_ProjectId",
                table: "Objectives");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Objectives",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Objectives_Projects_ProjectId",
                table: "Objectives",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objectives_Projects_ProjectId",
                table: "Objectives");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Objectives",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Objectives_Projects_ProjectId",
                table: "Objectives",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
