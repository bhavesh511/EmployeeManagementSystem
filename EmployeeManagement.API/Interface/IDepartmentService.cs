using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.API.Interface
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int DepartmentID);
    }
}
