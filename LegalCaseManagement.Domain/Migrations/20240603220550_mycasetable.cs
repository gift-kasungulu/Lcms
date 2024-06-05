using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalCaseManagement.Domain.Migrations
{
    public partial class mycasetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    LawyerId = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_MyTasks_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyTasks_Lawyers_LawyerId",
                        column: x => x.LawyerId,
                        principalTable: "Lawyers",
                        principalColumn: "LawyerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyTasks_PriorityLevel_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "PriorityLevel",
                        principalColumn: "PriorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyTasks_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyTasks_CaseId",
                table: "MyTasks",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_MyTasks_LawyerId",
                table: "MyTasks",
                column: "LawyerId");

            migrationBuilder.CreateIndex(
                name: "IX_MyTasks_PriorityId",
                table: "MyTasks",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_MyTasks_StatusId",
                table: "MyTasks",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyTasks");
        }
    }
}
