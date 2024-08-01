using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalCaseManagement.Domain.Migrations
{
    public partial class approvedappointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyTasks_Cases_CaseId",
                table: "MyTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_MyTasks_Cases_CaseId1",
                table: "MyTasks");

            migrationBuilder.DropIndex(
                name: "IX_MyTasks_CaseId1",
                table: "MyTasks");

            migrationBuilder.DropColumn(
                name: "CaseId1",
                table: "MyTasks");

            migrationBuilder.DropColumn(
                name: "LFirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LLastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_MyTasks_Cases_CaseId",
                table: "MyTasks",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyTasks_Cases_CaseId",
                table: "MyTasks");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "CaseId1",
                table: "MyTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LFirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LLastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MyTasks_CaseId1",
                table: "MyTasks",
                column: "CaseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MyTasks_Cases_CaseId",
                table: "MyTasks",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "CaseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MyTasks_Cases_CaseId1",
                table: "MyTasks",
                column: "CaseId1",
                principalTable: "Cases",
                principalColumn: "CaseId");
        }
    }
}
