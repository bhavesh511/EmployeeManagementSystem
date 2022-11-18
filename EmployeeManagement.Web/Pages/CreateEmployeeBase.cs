using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Interface;
using EmployeeManagement.Web.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class CreateEmployeeBase : ComponentBase
    {
        public Employee Employees { get; set; } = new Employee();

        [Inject]
        public IEmployeeWebService EmployeeWebService { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IDepartmentWebService DepartmentWebService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        public string DepartmentId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //int.TryParse(Id, out int employeeId);
            Departments = (await DepartmentWebService.GetDepartments()).ToList();
            DepartmentId = Employees.DepartmentID.ToString();           

            //if (employeeId != 0)
            //{
            //    Employees = new Employee()
            //    {
            //        DepartmentID = 1,
            //        DateOfBirth = System.DateTime.Now,
            //        PhotoPath = "images/employee-logo.png"
            //    };
            //}

        }

        protected async Task CreateSubmit()
        {
        }
    }
}
