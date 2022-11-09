using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "IT" },
                    { 3, "Payroll" },
                    { 4, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "DepartmentID", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john@gmail.com", "John", 0, "Hastings", "../images/employee-logo.png" },
                    { 2, new DateTime(1979, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mary@gmail.com", "Mary", 1, "Smith", "../images/employee-female-logo.png" },
                    { 3, new DateTime(1985, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "sam@gmail.com", "Sam", 0, "Galloway", "../images/employee-logo.png" },
                    { 4, new DateTime(1982, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "sara@gmail.com", "Sara", 0, "Longway", "../images/employee-female-logo.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
