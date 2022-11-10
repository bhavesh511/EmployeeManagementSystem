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
    public class EditEmployeeBase : ComponentBase
    {
        private Employee Employee { get; set; } = new Employee();

        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

        [Inject]
        public IEmployeeWebService EmployeeWebService { get; set; }

        [Inject]
        public IDepartmentWebService DepartmentWebService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        public string DepartmentId { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper mapper { get; set; } 

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeWebService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentWebService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartmentID.ToString();

            mapper.Map(Employee, EditEmployeeModel); 

            //EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.ConfirmEmail = Employee.Email;
            //EditEmployeeModel.DateOfBirth = Employee.DateOfBirth;
            //EditEmployeeModel.Gender = Employee.Gender;
            //EditEmployeeModel.DepartmentID = Employee.DepartmentID;
            //EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            //EditEmployeeModel.Departments = Employee.Departments;
        }

        protected void HandleValidSubmit()
        { 
        }
    }
}
