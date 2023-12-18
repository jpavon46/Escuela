﻿// <auto-generated />
using Escuela.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Escuela.Migrations
{
    [DbContext(typeof(EscuelaContext))]
    [Migration("20231217210220_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Escuela.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Escuela.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("School");
                });

            modelBuilder.Entity("Escuela.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Escuela.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SchoolId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("Escuela.Models.Course", b =>
                {
                    b.HasOne("Escuela.Models.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escuela.Models.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Escuela.Models.Teacher", b =>
                {
                    b.HasOne("Escuela.Models.School", "School")
                        .WithMany("Teachers")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("Escuela.Models.School", b =>
                {
                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Escuela.Models.Student", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Escuela.Models.Teacher", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
