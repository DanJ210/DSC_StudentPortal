using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentPortal.Migrations
{
    public partial class UpdatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_ProgressBars_ProgressBarBarid",
                table: "StudentClasses");

            migrationBuilder.RenameColumn(
                name: "ProgressBarBarid",
                table: "StudentClasses",
                newName: "ProgressBarBarId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_ProgressBarBarid",
                table: "StudentClasses",
                newName: "IX_StudentClasses_ProgressBarBarId");

            migrationBuilder.RenameColumn(
                name: "Barid",
                table: "ProgressBars",
                newName: "BarId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_ProgressBars_ProgressBarBarId",
                table: "StudentClasses",
                column: "ProgressBarBarId",
                principalTable: "ProgressBars",
                principalColumn: "BarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_ProgressBars_ProgressBarBarId",
                table: "StudentClasses");

            migrationBuilder.RenameColumn(
                name: "ProgressBarBarId",
                table: "StudentClasses",
                newName: "ProgressBarBarid");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_ProgressBarBarId",
                table: "StudentClasses",
                newName: "IX_StudentClasses_ProgressBarBarid");

            migrationBuilder.RenameColumn(
                name: "BarId",
                table: "ProgressBars",
                newName: "Barid");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_ProgressBars_ProgressBarBarid",
                table: "StudentClasses",
                column: "ProgressBarBarid",
                principalTable: "ProgressBars",
                principalColumn: "Barid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
