using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int EmployeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int EmployeeId);
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
    }
}
