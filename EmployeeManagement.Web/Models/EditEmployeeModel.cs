using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [CompareProperty("Email", ErrorMessage = "Email and Confirm Email do not match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentID { get; set; }
        public string PhotoPath { get; set; }

        [ValidateComplexType]
        public Department Departments { get; set; } = new Department();
    }
}
