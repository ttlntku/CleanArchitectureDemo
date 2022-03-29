﻿// <auto-generated />
using System;
using Employee.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employee.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("Employee.Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("char(10)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_Employee");

                    b.HasIndex("FirstName")
                        .HasDatabaseName("Idx_FirstName");

                    b.HasIndex("LastName")
                        .HasDatabaseName("Idx_LastName");

                    b.ToTable("tbl_employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified),
                            CreatedBy = "KIEU",
                            DateOfBirth = new DateTime(1999, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "kieungothekieu@gmail.com",
                            FirstName = "Kieu",
                            LastName = "Ngo",
                            Password = "kieu1",
                            PhoneNumber = "0965117209",
                            UpdatedAt = new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified),
                            UpdatedBy = "KIEU"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified),
                            CreatedBy = "KIEU",
                            DateOfBirth = new DateTime(1999, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "williamshakespeare@gmail.com",
                            FirstName = "William",
                            LastName = "Shakespeare",
                            Password = "william1",
                            PhoneNumber = "0965117209",
                            UpdatedAt = new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified),
                            UpdatedBy = "KIEU"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified),
                            CreatedBy = "KIEU",
                            DateOfBirth = new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "louisvuitton@gmail.com",
                            FirstName = "Louis",
                            LastName = "Vuitton",
                            Password = "louis1",
                            PhoneNumber = "0965117209",
                            UpdatedAt = new DateTime(2022, 3, 28, 10, 13, 12, 0, DateTimeKind.Unspecified),
                            UpdatedBy = "KIEU"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
