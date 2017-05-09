using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentPortal.Migrations
{
    public partial class DatabaseRefresh2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "ProgressBars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgressBars_StudentId",
                table: "ProgressBars",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressBars_Students_StudentId",
                table: "ProgressBars",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressBars_Students_StudentId",
                table: "ProgressBars");

            migrationBuilder.DropIndex(
                name: "IX_ProgressBars_StudentId",
                table: "ProgressBars");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ProgressBars");
        }
    }
}
