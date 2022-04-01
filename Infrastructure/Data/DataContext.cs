using Core.Helpers;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<EmployeeEntity> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // map entities to tables
            modelBuilder.Entity<EmployeeEntity>().ToTable("tbl_employee");

            ////configure primary key
            //modelBuilder.Entity<EmployeeEntity>().HasKey(e => e.Id).HasName("PK_Employee");

            ////configure indexes
            //modelBuilder.Entity<EmployeeEntity>().HasIndex(u => u.FirstName).HasDatabaseName("Idx_FirstName");
            //modelBuilder.Entity<EmployeeEntity>().HasIndex(u => u.LastName).HasDatabaseName("Idx_LastName");

            ////configure columns
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.FirstName).HasColumnType("nvarchar(50)").IsRequired();
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.LastName).HasColumnType("nvarchar(50)").IsRequired();
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.DateOfBirth).HasColumnType("datetime");
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.PhoneNumber).HasColumnType("char(10)");
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.Email).HasColumnType("nvarchar(50)").IsRequired();
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.Password).HasColumnType("nvarchar(50)").IsRequired();
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.Role).HasColumnType("bit").IsRequired();
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.CreatedBy).HasColumnType("nvarchar(50)").IsRequired();
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.CreatedAt).HasColumnType("datetime").IsRequired();
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.UpdatedBy).HasColumnType("nvarchar(50)").IsRequired();
            //modelBuilder.Entity<EmployeeEntity>().Property(u => u.UpdatedAt).HasColumnType("datetime").IsRequired();

            //seeding
            modelBuilder.Entity<EmployeeEntity>().HasData(
                new EmployeeEntity
                {
                    Id = 1,
                    FirstName = "Kieu",
                    LastName = "Ngo",
                    DateOfBirth = Convert.ToDateTime("1999/11/25 00:00:00"),
                    PhoneNumber = "0965117209",
                    Email = "kieungothekieu@gmail.com",
                    Password = "kieu1",
                    Role = EmployeeRole.ROLE_ADMIN,
                    CreatedBy = "KIEU",
                    CreatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now),
                    UpdatedBy = "KIEU",
                    UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now)
                },
                new EmployeeEntity
                {
                    Id = 2,
                    FirstName = "William",
                    LastName = "Shakespeare",
                    DateOfBirth = Convert.ToDateTime("1999/09/25 00:00:00"),
                    PhoneNumber = "0965117209",
                    Email = "williamshakespeare@gmail.com",
                    Password = "william1",
                    Role = EmployeeRole.ROLE_USER,
                    CreatedBy = "KIEU",
                    CreatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now),
                    UpdatedBy = "KIEU",
                    UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now)
                },
                new EmployeeEntity
                {
                    Id = 3,
                    FirstName = "Louis",
                    LastName = "Vuitton",
                    DateOfBirth = Convert.ToDateTime("1999/01/01 00:00:00"),
                    PhoneNumber = "0965117209",
                    Email = "louisvuitton@gmail.com",
                    Password = "louis1",
                    Role = EmployeeRole.ROLE_USER,
                    CreatedBy = "KIEU",
                    CreatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now),
                    UpdatedBy = "KIEU",
                    UpdatedAt = CustomUtilities.CustomDatetimeConvert(DateTime.Now)
                });
        }
    }
}
