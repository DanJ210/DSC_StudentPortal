using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentPortal.Migrations
{
    public partial class FirstNewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Professors_ClassProfessorId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Students_ScheduledStudentId",
                table: "StudentClasses");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "ScheduledStudentId",
                table: "StudentClasses",
                newName: "ProgressBarBarid");

            migrationBuilder.RenameColumn(
                name: "ClassProfessorId",
                table: "StudentClasses",
                newName: "ClassProfessorProfessorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentClasses",
                newName: "ScheduledId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_ScheduledStudentId",
                table: "StudentClasses",
                newName: "IX_StudentClasses_ProgressBarBarid");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_ClassProfessorId",
                table: "StudentClasses",
                newName: "IX_StudentClasses_ClassProfessorProfessorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Professors",
                newName: "ProfessorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "GraduationDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ScheduledClassScheduledId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StudentProgram",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "StudentClasses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "StudentClasses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ProgressBars",
                columns: table => new
                {
                    Barid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BarSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressBars", x => x.Barid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ScheduledClassScheduledId",
                table: "Students",
                column: "ScheduledClassScheduledId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Professors_ClassProfessorProfessorId",
                table: "StudentClasses",
                column: "ClassProfessorProfessorId",
                principalTable: "Professors",
                principalColumn: "ProfessorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_ProgressBars_ProgressBarBarid",
                table: "StudentClasses",
                column: "ProgressBarBarid",
                principalTable: "ProgressBars",
                principalColumn: "Barid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentClasses_ScheduledClassScheduledId",
                table: "Students",
                column: "ScheduledClassScheduledId",
                principalTable: "StudentClasses",
                principalColumn: "ScheduledId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Professors_ClassProfessorProfessorId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_ProgressBars_ProgressBarBarid",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentClasses_ScheduledClassScheduledId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ProgressBars");

            migrationBuilder.DropIndex(
                name: "IX_Students_ScheduledClassScheduledId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GraduationDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ScheduledClassScheduledId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentProgram",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "StudentClasses");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProgressBarBarid",
                table: "StudentClasses",
                newName: "ScheduledStudentId");

            migrationBuilder.RenameColumn(
                name: "ClassProfessorProfessorId",
                table: "StudentClasses",
                newName: "ClassProfessorId");

            migrationBuilder.RenameColumn(
                name: "ScheduledId",
                table: "StudentClasses",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_ProgressBarBarid",
                table: "StudentClasses",
                newName: "IX_StudentClasses_ScheduledStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_ClassProfessorProfessorId",
                table: "StudentClasses",
                newName: "IX_StudentClasses_ClassProfessorId");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Professors",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Professors_ClassProfessorId",
                table: "StudentClasses",
                column: "ClassProfessorId",
                principalTable: "Professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Students_ScheduledStudentId",
                table: "StudentClasses",
                column: "ScheduledStudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
