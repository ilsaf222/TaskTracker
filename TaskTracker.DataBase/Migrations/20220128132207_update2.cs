using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.DataBase.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Objectives_ObjectiveId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ObjectiveId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ObjectiveId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Objectives",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_ProjectId",
                table: "Objectives",
                column: "ProjectId");

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

            migrationBuilder.DropIndex(
                name: "IX_Objectives_ProjectId",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Objectives");

            migrationBuilder.AddColumn<int>(
                name: "ObjectiveId",
                table: "Projects",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ObjectiveId",
                table: "Projects",
                column: "ObjectiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Objectives_ObjectiveId",
                table: "Projects",
                column: "ObjectiveId",
                principalTable: "Objectives",
                principalColumn: "Id");
        }
    }
}
