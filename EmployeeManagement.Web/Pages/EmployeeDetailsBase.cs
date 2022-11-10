using EmployeeManagement.Models;
using EmployeeManagement.Web.Interface;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        
        [Inject]
        public IEmployeeWebService EmployeeWebService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeWebService.GetEmployee(int.Parse(Id));
        }
    }
}
