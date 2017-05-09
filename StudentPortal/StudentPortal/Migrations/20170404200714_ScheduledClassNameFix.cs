using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentPortal.Migrations
{
    public partial class ScheduledClassNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Students_SheduledStudentId",
                table: "StudentClasses");

            migrationBuilder.RenameColumn(
                name: "SheduledStudentId",
                table: "StudentClasses",
                newName: "ScheduledStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_SheduledStudentId",
                table: "StudentClasses",
                newName: "IX_StudentClasses_ScheduledStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Students_ScheduledStudentId",
                table: "StudentClasses",
                column: "ScheduledStudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Students_ScheduledStudentId",
                table: "StudentClasses");

            migrationBuilder.RenameColumn(
                name: "ScheduledStudentId",
                table: "StudentClasses",
                newName: "SheduledStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_ScheduledStudentId",
                table: "StudentClasses",
                newName: "IX_StudentClasses_SheduledStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Students_SheduledStudentId",
                table: "StudentClasses",
                column: "SheduledStudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
