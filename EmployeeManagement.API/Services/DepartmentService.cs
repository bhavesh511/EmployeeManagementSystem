using EmployeeManagement.API.Interface;
using EmployeeManagement.API.Models;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _appDbContext.Departments;
        }
        
        public Department GetDepartment(int DepartmentID)
        {
            return _appDbContext.Departments.FirstOrDefault(d => d.DepartmentID == DepartmentID);
        }
    }
}
