﻿// <auto-generated />
using System;
using EmployeeLeaveManagementSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeLeaveManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
<<<<<<<< HEAD:EmployeeLeaveManagementSystem/Migrations/20250212064433_Initial.Designer.cs
    [Migration("20250212064433_Initial")]
    partial class Initial
========
    [Migration("20250223175819_changs")]
    partial class changs
>>>>>>>> Feature_Sravya:EmployeeLeaveManagementSystem/Migrations/20250223175819_changs.Designer.cs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeLeaveManagementSystem.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaveBalance")
                        .HasColumnType("int");

                    b.Property<string>("OfficeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeLeaveManagementSystem.Model.LeaveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Leavetypeid")
                        .HasColumnType("int");

                    b.Property<int>("NoOfLeaves")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("EmployeeLeaveManagementSystem.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

<<<<<<<< HEAD:EmployeeLeaveManagementSystem/Migrations/20250212064433_Initial.Designer.cs
========
                    b.Property<int>("PendingOtherLeaves")
                        .HasColumnType("int");

                    b.Property<int>("PendingSickLeaves")
                        .HasColumnType("int");

                    b.Property<int>("PendingVacationLeaves")
                        .HasColumnType("int");

>>>>>>>> Feature_Sravya:EmployeeLeaveManagementSystem/Migrations/20250223175819_changs.Designer.cs
                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeeLeaveManagementSystem.Model.LeaveRequest", b =>
                {
                    b.HasOne("EmployeeLeaveManagementSystem.Model.Employee", "Employee")
                        .WithMany("LeaveRequest")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeLeaveManagementSystem.Model.User", b =>
                {
                    b.HasOne("EmployeeLeaveManagementSystem.Model.Employee", "Employee")
                        .WithOne("User")
                        .HasForeignKey("EmployeeLeaveManagementSystem.Model.User", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeLeaveManagementSystem.Model.Employee", b =>
                {
                    b.Navigation("LeaveRequest");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
