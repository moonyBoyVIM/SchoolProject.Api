﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolProject.Api.Data;

#nullable disable

namespace SchoolProject.Api.Data.Migrations
{
    [DbContext(typeof(SchoolProjectContext))]
    partial class SchoolProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("SchoolProject.Api.Entitiies.StudetnsEntities.CategoryStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CategoryStudents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Junior School"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Middle School"
                        },
                        new
                        {
                            Id = 3,
                            Name = "High School"
                        });
                });

            modelBuilder.Entity("SchoolProject.Api.Entitiies.StudetnsEntities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolProject.Api.Entitiies.Teachers.CategoryTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CategoryTeachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Math"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Biology"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Chemistry"
                        },
                        new
                        {
                            Id = 4,
                            Name = "History"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Physics"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Literature"
                        });
                });

            modelBuilder.Entity("SchoolProject.Api.Entitiies.Teachers.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolProject.Api.Entitiies.StudetnsEntities.Student", b =>
                {
                    b.HasOne("SchoolProject.Api.Entitiies.StudetnsEntities.CategoryStudent", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SchoolProject.Api.Entitiies.Teachers.Teacher", b =>
                {
                    b.HasOne("SchoolProject.Api.Entitiies.Teachers.CategoryTeacher", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}