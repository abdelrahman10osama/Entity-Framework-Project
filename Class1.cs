using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeProjectSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
            = new List<Employee>();
    }
}

namespace EmployeeProjectSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Project> Projects { get; set; }
            = new List<Project>();
    }
}

namespace EmployeeProjectSystem.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public ICollection<Employee> Employees { get; set; }
            = new List<Employee>();
    }
}

