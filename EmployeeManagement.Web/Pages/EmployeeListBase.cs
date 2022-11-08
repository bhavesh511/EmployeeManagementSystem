using Microsoft.AspNetCore.Components;
using System.Collections;
using EmployeeManagement.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadEmployees);
        }

        private void LoadEmployees()
        {
            Employee employee1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "john@gmail.com",
                DateOfBirth = new DateTime(1980, 10, 23),
                Gender = Gender.Male,
                Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
                PhotoPath = "../images/employee-logo.png"
            };

            Employee employee2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@gmail.com",
                DateOfBirth = new DateTime(1979, 09, 05),
                Gender = Gender.Female,
                Department = new Department { DepartmentId = 2, DepartmentName = "HR" },
                PhotoPath = "../images/employee-female-logo.png"
            };

            Employee employee3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "sam@gmail.com",
                DateOfBirth = new DateTime(1985, 01, 30),
                Gender = Gender.Male,
                Department = new Department { DepartmentId = 3, DepartmentName = "Payroll" },
                PhotoPath = "../images/employee-logo.png"
            };

            Employee employee4 = new Employee
            {
                EmployeeId = 4,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@gmail.com",
                DateOfBirth = new DateTime(1982, 06, 25),
                Gender = Gender.Male,
                Department = new Department { DepartmentId = 3, DepartmentName = "Payroll" },
                PhotoPath = "../images/employee-female-logo.png"
            };

            Employees = new List<Employee> { employee1, employee2, employee3, employee4 };

        }
    }
}
