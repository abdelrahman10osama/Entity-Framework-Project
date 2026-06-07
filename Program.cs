using EmployeeProjectSystem.Data;
using EmployeeProjectSystem.Models;

namespace EmployeeProjectSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static void AddDepartment()
            {
                using var context = new EmployeeProjectContext();

                Console.Write("Enter Department Name: ");
                string name = Console.ReadLine();

                Department department = new Department()
                {
                    DepartmentName = name
                };

                context.Departments.Add(department);

                context.SaveChanges();

                Console.WriteLine("Department Added Successfully");

                Console.WriteLine("\nDepartments:");

                foreach (var dept in context.Departments)
                {
                    Console.WriteLine($"{dept.DepartmentId} - {dept.DepartmentName}");
                }
            }

            static void AddEmployee()
            {
                using var context = new EmployeeProjectContext();

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Salary: ");
                decimal salary = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter Department Id:");
                var departments = context.Departments.ToList();

                for (int i = 0; i < departments.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {departments[i].DepartmentName}");
                }

                int choice = int.Parse(Console.ReadLine());
                int deptId = departments[choice - 1].DepartmentId;

                Employee emp = new Employee
                {
                    EmployeeName = name,
                    Salary = salary,
                    DepartmentId = deptId
                };

                context.Employees.Add(emp);
                context.SaveChanges();

                Console.WriteLine("Employee Added Successfully");
            }

            static void AddProject()
            {
                using var context = new EmployeeProjectContext();

                Console.Write("Enter Project Name: ");
                string name = Console.ReadLine();

                Project project = new Project
                {
                    ProjectName = name
                };

                context.Projects.Add(project);
                context.SaveChanges();

                Console.WriteLine("Project Added Successfully");
            }
            static void AssignEmployeeToProject()
            {
                using var context = new EmployeeProjectContext();

                var employees = context.Employees.ToList();
                var projects = context.Projects.ToList();

                Console.WriteLine("Choose Employee:");

                for (int i = 0; i < employees.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {employees[i].EmployeeName}");
                }

                int empChoice = int.Parse(Console.ReadLine());
                var employee = employees[empChoice - 1];

                Console.WriteLine("Choose Project:");

                for (int i = 0; i < projects.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {projects[i].ProjectName}");
                }

                int projChoice = int.Parse(Console.ReadLine());
                var project = projects[projChoice - 1];

                employee.Projects.Add(project);

                context.SaveChanges();

                Console.WriteLine("Employee Assigned To Project Successfully");
            }

            static void DisplayEmployees()
            {
                using var context = new EmployeeProjectContext();

                var employees = context.Employees
                    .Select(e => new
                    {
                        e.EmployeeId,
                        e.EmployeeName,
                        e.Salary,
                        Department = e.Department.DepartmentName,
                        Projects = e.Projects.Select(p => p.ProjectName).ToList()
                    })
                    .ToList();

                foreach (var e in employees)
                {
                    Console.WriteLine($"ID: {e.EmployeeId}");
                    Console.WriteLine($"Name: {e.EmployeeName}");
                    Console.WriteLine($"Salary: {e.Salary}");
                    Console.WriteLine($"Department: {e.Department}");

                    Console.WriteLine("Projects:");
                    foreach (var p in e.Projects)
                    {
                        Console.WriteLine($" - {p}");
                    }

                    Console.WriteLine("----------------------");
                }
            }

            static void DisplayDepartments()
            {
                using var context = new EmployeeProjectContext();

                var departments = context.Departments
                    .Select(d => new
                    {
                        d.DepartmentId,
                        d.DepartmentName,
                        Employees = d.Employees.Select(e => e.EmployeeName).ToList()
                    })
                    .ToList();

                foreach (var d in departments)
                {
                    Console.WriteLine($"ID: {d.DepartmentId}");
                    Console.WriteLine($"Name: {d.DepartmentName}");

                    Console.WriteLine("Employees:");
                    foreach (var e in d.Employees)
                    {
                        Console.WriteLine($" - {e}");
                    }

                    Console.WriteLine("----------------------");
                }
            }

            static void DisplayProjects()
            {
                using var context = new EmployeeProjectContext();

                var projects = context.Projects
                    .Select(p => new
                    {
                        p.ProjectId,
                        p.ProjectName,
                        Employees = p.Employees.Select(e => e.EmployeeName).ToList()
                    })
                    .ToList();

                foreach (var p in projects)
                {
                    Console.WriteLine($"ID: {p.ProjectId}");
                    Console.WriteLine($"Name: {p.ProjectName}");

                    Console.WriteLine("Employees:");
                    foreach (var e in p.Employees)
                    {
                        Console.WriteLine($" - {e}");
                    }

                    Console.WriteLine("----------------------");
                }
            }


            using var context = new EmployeeProjectContext();

            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("===== Employee Project Management System =====");
                Console.WriteLine("1- Add");
                Console.WriteLine("2- Edit");
                Console.WriteLine("3- Delete");
                Console.WriteLine("4- Display");
                Console.WriteLine("0- Exit");
                Console.Write("Choose: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1- Add Department");
                        Console.WriteLine("2- Add Employee");
                        Console.WriteLine("3- Add Project");
                        Console.WriteLine("4- Assign Employee ");

                        int addChoice = int.Parse(Console.ReadLine());

                        switch (addChoice)
                        {
                            case 1:
                                AddDepartment();
                                break;
                            case 2:
                                AddEmployee();
                                break;
                            case 3:
                                AddProject();
                                break;
                            case 4:
                                AssignEmployeeToProject();
                                break;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Edit Menu");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("Delete Menu");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine("1- Display Employees");
                        Console.WriteLine("2- Display Departments");
                        Console.WriteLine("3- Display Projects");

                        int displayChoice = int.Parse(Console.ReadLine());

                        switch (displayChoice)
                        {
                            case 1:
                                DisplayEmployees();
                                break;
                            case 2:
                                DisplayDepartments();
                                break;
                            case 3:
                                DisplayProjects();
                                break;
                        }

                        Console.ReadKey();
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }

            if (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key...");
                    Console.ReadKey();
                }
            }
        }
    }
