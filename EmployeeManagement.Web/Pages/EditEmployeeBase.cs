using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Interface;
using EmployeeManagement.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        private Employee Employee { get; set; } = new Employee();
        private InsertEmployee InsertEmployee { get; set; } = new InsertEmployee();

        public string PageHeaderText { get; set;}

        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

        [Inject]
        public IEmployeeWebService EmployeeWebService { get; set; }

        [Inject]
        public IDepartmentWebService DepartmentWebService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        //public string DepartmentId { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper mapper { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);
            Departments = (await DepartmentWebService.GetDepartments()).ToList();
            //DepartmentId = Employee.DepartmentID.ToString();
                
            if (employeeId != 0)
            {
                PageHeaderText = "Edit Employee";
                Employee = await EmployeeWebService.GetEmployee(int.Parse(Id));
                mapper.Map(Employee, EditEmployeeModel);
            }
            else
            {
                PageHeaderText = "Create Employee";
                Employee = new Employee()
                {
                    Departments = (await DepartmentWebService.GetDepartments()).FirstOrDefault(),
                    //DepartmentID = 1,
                    DateOfBirth =  DateTime.Now,
                    PhotoPath = "images/employee-logo.png",
                };
                mapper.Map(Employee, EditEmployeeModel);
            }




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

        protected async Task HandleValidSubmit()
        {


            var result = "";
            //Employee result = null;

            if(Employee.EmployeeId != 0)
            {
                mapper.Map(EditEmployeeModel, Employee);
                result = await EmployeeWebService.UpdateEmployee(Employee);
            }
            else
            {
                mapper.Map(EditEmployeeModel, InsertEmployee);
                result = await EmployeeWebService.CreateEmployee(InsertEmployee);
            }

            if (result != null)
            {
                navigationManager.NavigateTo("/");
            }
        }

        protected async Task deleteClick()
        {
            await EmployeeWebService.DeleteEmployee(Employee.EmployeeId);
            navigationManager.NavigateTo("/");
        }
    }
}
