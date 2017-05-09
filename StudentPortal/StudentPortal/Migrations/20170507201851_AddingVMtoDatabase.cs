using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentPortal.Migrations
{
    public partial class AddingVMtoDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DatabaseVMId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DatabaseVMId",
                table: "StudentClasses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DatabaseVMId",
                table: "ProgressBars",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DatabaseVMId",
                table: "Professors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DatabaseVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseVM", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DatabaseVMId",
                table: "Students",
                column: "DatabaseVMId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_DatabaseVMId",
                table: "StudentClasses",
                column: "DatabaseVMId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressBars_DatabaseVMId",
                table: "ProgressBars",
                column: "DatabaseVMId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_DatabaseVMId",
                table: "Professors",
                column: "DatabaseVMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_DatabaseVM_DatabaseVMId",
                table: "Professors",
                column: "DatabaseVMId",
                principalTable: "DatabaseVM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressBars_DatabaseVM_DatabaseVMId",
                table: "ProgressBars",
                column: "DatabaseVMId",
                principalTable: "DatabaseVM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_DatabaseVM_DatabaseVMId",
                table: "StudentClasses",
                column: "DatabaseVMId",
                principalTable: "DatabaseVM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_DatabaseVM_DatabaseVMId",
                table: "Students",
                column: "DatabaseVMId",
                principalTable: "DatabaseVM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professors_DatabaseVM_DatabaseVMId",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgressBars_DatabaseVM_DatabaseVMId",
                table: "ProgressBars");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_DatabaseVM_DatabaseVMId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_DatabaseVM_DatabaseVMId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "DatabaseVM");

            migrationBuilder.DropIndex(
                name: "IX_Students_DatabaseVMId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasses_DatabaseVMId",
                table: "StudentClasses");

            migrationBuilder.DropIndex(
                name: "IX_ProgressBars_DatabaseVMId",
                table: "ProgressBars");

            migrationBuilder.DropIndex(
                name: "IX_Professors_DatabaseVMId",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "DatabaseVMId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DatabaseVMId",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "DatabaseVMId",
                table: "ProgressBars");

            migrationBuilder.DropColumn(
                name: "DatabaseVMId",
                table: "Professors");
        }
    }
}
