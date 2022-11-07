using Microsoft.AspNetCore.Components;
using System.Collections;
using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}
