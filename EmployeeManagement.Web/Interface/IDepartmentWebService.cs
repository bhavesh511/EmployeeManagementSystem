using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Interface
{
    public interface IDepartmentWebService
    {
        public Task<IEnumerable<Department>> GetDepartments();

        public Task<Department> GetDepartment(int id);
    }
}
