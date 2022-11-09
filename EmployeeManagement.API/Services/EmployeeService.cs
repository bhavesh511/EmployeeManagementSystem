using EmployeeManagement.API.Interface;
using EmployeeManagement.API.Models;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int EmployeeId)
        {
            var result = await _appDbContext.Employees
             .FirstOrDefaultAsync(e => e.EmployeeId == EmployeeId);
            if (result != null)
            {
                _appDbContext.Employees.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Employee> GetEmployee(int EmployeeId)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == EmployeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentID = employee.DepartmentID;
                result.PhotoPath = employee.PhotoPath;

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = _appDbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                            || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }
    }
}
