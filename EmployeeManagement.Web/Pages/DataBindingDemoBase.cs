using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DataBindingDemoBase : ComponentBase
    {
        protected string Name { get; set; } = "John";
        protected string Gender { get; set; } = "Male";

        protected string Description { get; set; } = string.Empty;

    }
}
