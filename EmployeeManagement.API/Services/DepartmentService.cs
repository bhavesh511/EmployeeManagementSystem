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
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _appDbContext.Departments.ToListAsync();
        }
        
        public async Task<Department> GetDepartment(int DepartmentID)
        {
            return await _appDbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentID == DepartmentID);
        }
    }
}
