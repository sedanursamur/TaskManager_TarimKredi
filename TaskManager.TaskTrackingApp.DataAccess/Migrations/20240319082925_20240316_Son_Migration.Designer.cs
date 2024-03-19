﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager.TaskTrackingApp.DataAccess.Context;

#nullable disable

namespace TaskManager.TaskTrackingApp.DataAccess.Migrations
{
    [DbContext(typeof(TaskTrackingContext))]
    [Migration("20240319082925_20240316_Son_Migration")]
    partial class _20240316_Son_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Defination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Defination")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PriortryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("PriortryId");

                    b.ToTable("AppTasks");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppTaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Defination")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TaskStatuses");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DegreeId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DegreeId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppRoleId")
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("AppRoleId", "AppUserId")
                        .IsUnique();

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppUserTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppTaskId")
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("CompleteDocumentDefination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CompletedTaskDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("DocumentPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TaskEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppTaskId")
                        .IsUnique();

                    b.HasIndex("TaskStatusId");

                    b.HasIndex("AppUserId", "AppTaskId")
                        .IsUnique();

                    b.ToTable("AppUserTasks");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.Degree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Defination")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.Priortry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Defination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Priortries");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppTask", b =>
                {
                    b.HasOne("TaskManager.TaskTrackingApp.Entities.Priortry", "Priortry")
                        .WithMany("AppTasks")
                        .HasForeignKey("PriortryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Priortry");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppUser", b =>
                {
                    b.HasOne("TaskManager.TaskTrackingApp.Entities.Degree", "Degree")
                        .WithMany("AppUsers")
                        .HasForeignKey("DegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Degree");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppUserRole", b =>
                {
                    b.HasOne("TaskManager.TaskTrackingApp.Entities.AppRole", "AppRole")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManager.TaskTrackingApp.Entities.AppUser", "AppUser")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppRole");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppUserTask", b =>
                {
                    b.HasOne("TaskManager.TaskTrackingApp.Entities.AppTask", "AppTask")
                        .WithOne("AppUserTask")
                        .HasForeignKey("TaskManager.TaskTrackingApp.Entities.AppUserTask", "AppTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManager.TaskTrackingApp.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManager.TaskTrackingApp.Entities.AppTaskStatus", "TaskStatus")
                        .WithMany("AppUserTasks")
                        .HasForeignKey("TaskStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppTask");

                    b.Navigation("AppUser");

                    b.Navigation("TaskStatus");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppRole", b =>
                {
                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppTask", b =>
                {
                    b.Navigation("AppUserTask");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppTaskStatus", b =>
                {
                    b.Navigation("AppUserTasks");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.AppUser", b =>
                {
                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.Degree", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("TaskManager.TaskTrackingApp.Entities.Priortry", b =>
                {
                    b.Navigation("AppTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
