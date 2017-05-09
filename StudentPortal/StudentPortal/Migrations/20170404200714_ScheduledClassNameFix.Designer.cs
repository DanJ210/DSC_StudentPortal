using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StudentPortal.Models;

namespace StudentPortal.Migrations
{
    [DbContext(typeof(SchoolDatabaseContext))]
    [Migration("20170404200714_ScheduledClassNameFix")]
    partial class ScheduledClassNameFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentPortal.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProfessorName");

                    b.HasKey("Id");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("StudentPortal.Models.ScheduledClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassName");

                    b.Property<int?>("ClassProfessorId");

                    b.Property<int?>("ScheduledStudentId");

                    b.HasKey("Id");

                    b.HasIndex("ClassProfessorId");

                    b.HasIndex("ScheduledStudentId");

                    b.ToTable("StudentClasses");
                });

            modelBuilder.Entity("StudentPortal.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StudentName");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentPortal.Models.ScheduledClass", b =>
                {
                    b.HasOne("StudentPortal.Models.Professor", "ClassProfessor")
                        .WithMany()
                        .HasForeignKey("ClassProfessorId");

                    b.HasOne("StudentPortal.Models.Student", "ScheduledStudent")
                        .WithMany()
                        .HasForeignKey("ScheduledStudentId");
                });
        }
    }
}
