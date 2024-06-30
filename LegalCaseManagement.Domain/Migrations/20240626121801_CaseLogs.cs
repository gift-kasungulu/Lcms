using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegalCaseManagement.Domain.Migrations
{
    public partial class CaseLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Cases",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CreatedByUserId",
                table: "Cases",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_AspNetUsers_CreatedByUserId",
                table: "Cases",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_AspNetUsers_CreatedByUserId",
                table: "Cases");

            migrationBuilder.DropIndex(
                name: "IX_Cases_CreatedByUserId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Cases");
        }
    }
}
