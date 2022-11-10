using EmployeeManagement.Models;
using EmployeeManagement.Web.Interface;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
namespace EmployeeManagement.Web.Services
{
    public class EmployeeWebService : IEmployeeWebService
    {
        private readonly HttpClient _httpClient;

        public EmployeeWebService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/employee/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<Employee[]>("api/employee");
        }
    }
}
