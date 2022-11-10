using EmployeeManagement.Models;
using EmployeeManagement.Web.Interface;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeWebService EmployeeWebService { get; set; }

        [Inject]
        public IDepartmentWebService DepartmentWebService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        public string DepartmentId { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeWebService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentWebService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartmentID.ToString();
        }
    }
}
