using EmployeeManagement.Models;
using EmployeeManagement.Web.Interface;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Nodes;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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

        public async Task<string> UpdateEmployee(Employee updateEmployee)
        {
            
            
            var result = await _httpClient.PutAsJsonAsync<Employee>("api/employee", updateEmployee);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return "success"  ;
            }
            return null;
        }
        
        public async Task<string> CreateEmployee(InsertEmployee newEmployee)
        {
            var result = await _httpClient.PostAsJsonAsync<InsertEmployee>("api/employee", newEmployee);
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return "success";
            }
            else
            {
                return "failed";
            }
        }

        public async Task DeleteEmployee(int id)
        {
            await _httpClient.DeleteAsync($"api/employee/{id}");
        }
    }
}
