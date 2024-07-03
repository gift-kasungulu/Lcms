using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalCaseManagement.Domain.Migrations
{
    public partial class CaseAssignedtoLAwyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaseId1",
                table: "MyTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedLawyerId",
                table: "Cases",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MyTasks_CaseId1",
                table: "MyTasks",
                column: "CaseId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_AssignedLawyerId",
                table: "Cases",
                column: "AssignedLawyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_AspNetUsers_AssignedLawyerId",
                table: "Cases",
                column: "AssignedLawyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MyTasks_Cases_CaseId1",
                table: "MyTasks",
                column: "CaseId1",
                principalTable: "Cases",
                principalColumn: "CaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_AspNetUsers_AssignedLawyerId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_MyTasks_Cases_CaseId1",
                table: "MyTasks");

            migrationBuilder.DropIndex(
                name: "IX_MyTasks_CaseId1",
                table: "MyTasks");

            migrationBuilder.DropIndex(
                name: "IX_Cases_AssignedLawyerId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseId1",
                table: "MyTasks");

            migrationBuilder.DropColumn(
                name: "AssignedLawyerId",
                table: "Cases");
        }
    }
}
