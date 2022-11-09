using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 1, DepartmentName = "HR" },
                new Department { DepartmentID = 2, DepartmentName = "IT" },
                new Department { DepartmentID = 3, DepartmentName = "Payroll" },
                new Department { DepartmentID = 4, DepartmentName = "Admin" }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Hastings",
                    Email = "john@gmail.com",
                    DateOfBirth = new DateTime(1980, 10, 23),
                    Gender = Gender.Male,
                    DepartmentID = 1,
                    PhotoPath = "../images/employee-logo.png"
                },
            new Employee
            {
                EmployeeId = 2,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@gmail.com",
                DateOfBirth = new DateTime(1979, 09, 05),
                Gender = Gender.Female,
                DepartmentID = 2,
                PhotoPath = "../images/employee-female-logo.png"
            },
            new Employee
            {
                EmployeeId = 3,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "sam@gmail.com",
                DateOfBirth = new DateTime(1985, 01, 30),
                Gender = Gender.Male,
                DepartmentID = 3,
                PhotoPath = "../images/employee-logo.png"
            },
            new Employee
            {
                EmployeeId = 4,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@gmail.com",
                DateOfBirth = new DateTime(1982, 06, 25),
                Gender = Gender.Male,
                DepartmentID = 3,
                PhotoPath = "../images/employee-female-logo.png"
            });
        }
    }
}
