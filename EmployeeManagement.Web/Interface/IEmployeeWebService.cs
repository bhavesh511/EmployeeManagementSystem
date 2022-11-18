using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Interface
{
    public interface IEmployeeWebService
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int id);

        Task<string> UpdateEmployee(Employee updateEmployee);

        Task<string> CreateEmployee(InsertEmployee newEmployee);
        
        Task DeleteEmployee(int id);
    }
}
