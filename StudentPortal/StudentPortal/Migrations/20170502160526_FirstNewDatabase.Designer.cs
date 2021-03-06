﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StudentPortal.Models;

namespace StudentPortal.Migrations
{
    [DbContext(typeof(SchoolDatabaseContext))]
    [Migration("20170502160526_FirstNewDatabase")]
    partial class FirstNewDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentPortal.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProfessorName");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("StudentPortal.Models.ProgressBar", b =>
                {
                    b.Property<int>("Barid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BarSize");

                    b.HasKey("Barid");

                    b.ToTable("ProgressBars");
                });

            modelBuilder.Entity("StudentPortal.Models.ScheduledClass", b =>
                {
                    b.Property<int>("ScheduledId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassName");

                    b.Property<int?>("ClassProfessorProfessorId");

                    b.Property<DateTime>("EndDate");

                    b.Property<int?>("ProgressBarBarid");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ScheduledId");

                    b.HasIndex("ClassProfessorProfessorId");

                    b.HasIndex("ProgressBarBarid");

                    b.ToTable("StudentClasses");
                });

            modelBuilder.Entity("StudentPortal.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("GraduationDate");

                    b.Property<int?>("ScheduledClassScheduledId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("StudentName");

                    b.Property<string>("StudentProgram");

                    b.HasKey("StudentId");

                    b.HasIndex("ScheduledClassScheduledId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentPortal.Models.ScheduledClass", b =>
                {
                    b.HasOne("StudentPortal.Models.Professor", "ClassProfessor")
                        .WithMany()
                        .HasForeignKey("ClassProfessorProfessorId");

                    b.HasOne("StudentPortal.Models.ProgressBar")
                        .WithMany("ClassCompleted")
                        .HasForeignKey("ProgressBarBarid");
                });

            modelBuilder.Entity("StudentPortal.Models.Student", b =>
                {
                    b.HasOne("StudentPortal.Models.ScheduledClass")
                        .WithMany("ScheduledStudent")
                        .HasForeignKey("ScheduledClassScheduledId");
                });
        }
    }
}
