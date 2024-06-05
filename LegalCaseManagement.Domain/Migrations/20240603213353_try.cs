using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalCaseManagement.Domain.Migrations
{
    public partial class @try : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedLawyerLawyerId",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LawyerId",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PriorityLevel",
                columns: table => new
                {
                    PriorityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorityLevel", x => x.PriorityId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_AssignedLawyerLawyerId",
                table: "Cases",
                column: "AssignedLawyerLawyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Lawyers_AssignedLawyerLawyerId",
                table: "Cases",
                column: "AssignedLawyerLawyerId",
                principalTable: "Lawyers",
                principalColumn: "LawyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Lawyers_AssignedLawyerLawyerId",
                table: "Cases");

            migrationBuilder.DropTable(
                name: "PriorityLevel");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Cases_AssignedLawyerLawyerId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "AssignedLawyerLawyerId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "LawyerId",
                table: "Cases");
        }
    }
}
