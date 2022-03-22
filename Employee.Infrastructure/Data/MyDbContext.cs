using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Employee.Core.Entities.Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // map entities to tables
            modelBuilder.Entity<Employee.Core.Entities.Employee>().ToTable("tbl_employee");

            //configure primary key
            modelBuilder.Entity<Employee.Core.Entities.Employee>().HasKey(e => e.Id).HasName("PK_Employee");

            //configure indexes
            modelBuilder.Entity<Employee.Core.Entities.Employee>().HasIndex(u => u.FirstName).HasDatabaseName("Idx_FirstName");
            modelBuilder.Entity<Employee.Core.Entities.Employee>().HasIndex(u => u.LastName).HasDatabaseName("Idx_LastName");

            //configure columns
            modelBuilder.Entity<Employee.Core.Entities.Employee>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Employee.Core.Entities.Employee>().Property(u => u.FirstName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Employee.Core.Entities.Employee>().Property(u => u.LastName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Employee.Core.Entities.Employee>().Property(u => u.DateOfBirth).HasColumnType("datetime");
            modelBuilder.Entity<Employee.Core.Entities.Employee>().Property(u => u.PhoneNumber).HasColumnType("char(10)");
            modelBuilder.Entity<Employee.Core.Entities.Employee>().Property(u => u.Email).HasColumnType("nvarchar(50)").IsRequired();

            //seeding
            modelBuilder.Entity<Employee.Core.Entities.Employee>().HasData(
                new Employee.Core.Entities.Employee
                {
                    Id = 1,
                    FirstName = "Kieu",
                    LastName = "Ngo",
                    DateOfBirth = Convert.ToDateTime("1999/11/25 00:00:00"),
                    PhoneNumber = "0965117209",
                    Email = "kieungothekieu@gmail.com"
                },
                new Employee.Core.Entities.Employee
                {
                    Id = 2,
                    FirstName = "William",
                    LastName = "Shakespeare",
                    DateOfBirth = Convert.ToDateTime("1999/09/25 00:00:00"),
                    PhoneNumber = "0965117209",
                    Email = "williamshakespeare@gmail.com"
                },
                new Employee.Core.Entities.Employee
                {
                    Id = 3,
                    FirstName = "Louis",
                    LastName = "Vuitton",
                    DateOfBirth = Convert.ToDateTime("1999/01/01 00:00:00"),
                    PhoneNumber = "0965117209",
                    Email = "louisvuitton@gmail.com"
                });
        }
    }
}
