using EmployeeManagement.Models;
using EmployeeManagement.Web.Interface;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentWebService : IDepartmentWebService
    {
        private readonly HttpClient _httpClient;

        public DepartmentWebService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _httpClient.GetFromJsonAsync<Department[]>("api/department");
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await _httpClient.GetFromJsonAsync<Department>($"api/department/{id}");
        }

    }
}
