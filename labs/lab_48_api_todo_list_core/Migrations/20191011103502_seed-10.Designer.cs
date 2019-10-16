﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab_48_api_todo_list_core;

namespace lab_48_api_todo_list_core.Migrations
{
    [DbContext(typeof(TaskItemContext))]
    [Migration("20191011103502_seed-10")]
    partial class seed10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("lab_48_api_todo_list_core.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new { CategoryID = 1, CategoryName = "Cat Name Here", Description = "Description Here" },
                        new { CategoryID = 2, CategoryName = "Cat Name Here", Description = "Description Here" },
                        new { CategoryID = 3, CategoryName = "Cat Name Here", Description = "Description Here" },
                        new { CategoryID = 4, CategoryName = "Cat Name Here", Description = "Description Here" }
                    );
                });

            modelBuilder.Entity("lab_48_api_todo_list_core.TaskItem", b =>
                {
                    b.Property<int>("TaskItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryID");

                    b.Property<DateTime?>("DateDue");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<bool>("TaskDone");

                    b.Property<int?>("UserID");

                    b.Property<int?>("UserID1");

                    b.HasKey("TaskItemID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserID1");

                    b.ToTable("TaskItems");

                    b.HasData(
                        new { TaskItemID = 1, DateDue = new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description Here", TaskDone = true },
                        new { TaskItemID = 2, DateDue = new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description Here", TaskDone = true },
                        new { TaskItemID = 3, DateDue = new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description Here", TaskDone = true },
                        new { TaskItemID = 4, DateDue = new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description Here", TaskDone = true }
                    );
                });

            modelBuilder.Entity("lab_48_api_todo_list_core.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TaskItemID");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new { UserID = 1, Username = "User's name here" },
                        new { UserID = 2, Username = "User's name here" },
                        new { UserID = 3, Username = "User's name here" },
                        new { UserID = 4, Username = "User's name here" }
                    );
                });

            modelBuilder.Entity("lab_48_api_todo_list_core.TaskItem", b =>
                {
                    b.HasOne("lab_48_api_todo_list_core.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("lab_48_api_todo_list_core.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID1");
                });
#pragma warning restore 612, 618
        }
    }
}