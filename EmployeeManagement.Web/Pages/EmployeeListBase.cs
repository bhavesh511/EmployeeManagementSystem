using Microsoft.AspNetCore.Components;
using System.Collections;
using EmployeeManagement.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using EmployeeManagement.Web.Interface;
using System.Linq;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeWebService EmployeeWebService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

      

        public bool ShowFooter { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeWebService.GetEmployees()).ToList();
            
            //await Task.Run(LoadEmployees);
        }

        public int SelectedEmployeesCount { get; set; } = 0;

        protected async Task EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }

        protected async Task EmployeeDeleted()
        {
            Employees = (await EmployeeWebService.GetEmployees()).ToList();
        }

        //private void LoadEmployees()
        //{
        //    System.Threading.Thread.Sleep(3000);
        //    Employee employee1 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "John",
        //        LastName = "Hastings",
        //        Email = "john@gmail.com",
        //        DateOfBirth = new DateTime(1980, 10, 23),
        //        Gender = Gender.Male,
        //        DepartmentID = 1, 
        //        PhotoPath = "../images/employee-logo.png"
        //    };

        //    Employee employee2 = new Employee
        //    {
        //        EmployeeId = 2,
        //        FirstName = "Mary",
        //        LastName = "Smith",
        //        Email = "mary@gmail.com",
        //        DateOfBirth = new DateTime(1979, 09, 05),
        //        Gender = Gender.Female,
        //        DepartmentID = 2,
        //        PhotoPath = "../images/employee-female-logo.png"
        //    };

        //    Employee employee3 = new Employee
        //    {
        //        EmployeeId = 3,
        //        FirstName = "Sam",
        //        LastName = "Galloway",
        //        Email = "sam@gmail.com",
        //        DateOfBirth = new DateTime(1985, 01, 30),
        //        Gender = Gender.Male,
        //        DepartmentID = 3,
        //        PhotoPath = "../images/employee-logo.png"
        //    };

        //    Employee employee4 = new Employee
        //    {
        //        EmployeeId = 4,
        //        FirstName = "Sara",
        //        LastName = "Longway",
        //        Email = "sara@gmail.com",
        //        DateOfBirth = new DateTime(1982, 06, 25),
        //        Gender = Gender.Male,
        //        DepartmentID = 3,
        //        PhotoPath = "../images/employee-female-logo.png"
        //    };

        //    Employees = new List<Employee> { employee1, employee2, employee3, employee4 };

        //}
    }
}
