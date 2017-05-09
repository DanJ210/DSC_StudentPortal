using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StudentPortal.Models;

namespace StudentPortal.Migrations
{
    [DbContext(typeof(SchoolDatabaseContext))]
    partial class SchoolDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentPortal.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DatabaseVMId");

                    b.Property<string>("ProfessorName");

                    b.HasKey("ProfessorId");

                    b.HasIndex("DatabaseVMId");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("StudentPortal.Models.ProgressBar", b =>
                {
                    b.Property<int>("BarId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BarSize");

                    b.Property<int?>("DatabaseVMId");

                    b.Property<int?>("StudentId");

                    b.HasKey("BarId");

                    b.HasIndex("DatabaseVMId");

                    b.HasIndex("StudentId");

                    b.ToTable("ProgressBars");
                });

            modelBuilder.Entity("StudentPortal.Models.ScheduledClass", b =>
                {
                    b.Property<int>("ScheduledId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassName");

                    b.Property<int?>("ClassProfessorProfessorId");

                    b.Property<int?>("DatabaseVMId");

                    b.Property<DateTime>("EndDate");

                    b.Property<int?>("ProgressBarBarId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ScheduledId");

                    b.HasIndex("ClassProfessorProfessorId");

                    b.HasIndex("DatabaseVMId");

                    b.HasIndex("ProgressBarBarId");

                    b.ToTable("StudentClasses");
                });

            modelBuilder.Entity("StudentPortal.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DatabaseVMId");

                    b.Property<DateTime>("GraduationDate");

                    b.Property<int?>("ScheduledClassScheduledId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("StudentName");

                    b.Property<string>("StudentProgram");

                    b.HasKey("StudentId");

                    b.HasIndex("DatabaseVMId");

                    b.HasIndex("ScheduledClassScheduledId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentPortal.Models.ViewModels.DatabaseVM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("DatabaseVM");
                });

            modelBuilder.Entity("StudentPortal.Models.Professor", b =>
                {
                    b.HasOne("StudentPortal.Models.ViewModels.DatabaseVM")
                        .WithMany("Professors")
                        .HasForeignKey("DatabaseVMId");
                });

            modelBuilder.Entity("StudentPortal.Models.ProgressBar", b =>
                {
                    b.HasOne("StudentPortal.Models.ViewModels.DatabaseVM")
                        .WithMany("ProgressBars")
                        .HasForeignKey("DatabaseVMId");

                    b.HasOne("StudentPortal.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("StudentPortal.Models.ScheduledClass", b =>
                {
                    b.HasOne("StudentPortal.Models.Professor", "ClassProfessor")
                        .WithMany()
                        .HasForeignKey("ClassProfessorProfessorId");

                    b.HasOne("StudentPortal.Models.ViewModels.DatabaseVM")
                        .WithMany("ScheduledClasses")
                        .HasForeignKey("DatabaseVMId");

                    b.HasOne("StudentPortal.Models.ProgressBar")
                        .WithMany("ClassCompleted")
                        .HasForeignKey("ProgressBarBarId");
                });

            modelBuilder.Entity("StudentPortal.Models.Student", b =>
                {
                    b.HasOne("StudentPortal.Models.ViewModels.DatabaseVM")
                        .WithMany("Students")
                        .HasForeignKey("DatabaseVMId");

                    b.HasOne("StudentPortal.Models.ScheduledClass")
                        .WithMany("ScheduledStudents")
                        .HasForeignKey("ScheduledClassScheduledId");
                });
        }
    }
}
