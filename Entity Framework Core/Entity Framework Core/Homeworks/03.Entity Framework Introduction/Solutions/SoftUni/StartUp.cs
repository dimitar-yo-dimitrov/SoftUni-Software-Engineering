using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            // Just change the name of the method to see its result
            string result = IncreaseSalaries(dbContext);

            Console.WriteLine(result);
        }

        // 03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder employeesFullInformation = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in employees)
            {
                employeesFullInformation
                    .AppendLine(
                        $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return employeesFullInformation.ToString().TrimEnd();
        }

        // 04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            decimal salaryLevel = 50000;

            var employees = context.Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > salaryLevel)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            string departmentName = "Research and Development";

            var employees = context.Employees
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department,
                    e.Salary
                })
                .Where(e => e.Department.Name == departmentName)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 06. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            string lastName = "Nakov";
            string addressText = "Vitoshka 15";
            int townId = 4;

            var address = new Address
            {
                AddressText = addressText,
                TownId = townId
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            var person = context.Employees
                .First(e => e.LastName == lastName);

            person.AddressId = address.AddressId;

            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(a => a.AddressId)
                .Select(a => new
                {
                    a.Address.AddressId,
                    a.Address.AddressText
                })
                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine(a.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        // 07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(e => e.Project)
                .Where(e => e.EmployeesProjects
                    .Any(p => p.Project.StartDate.Year >= 2001
                              && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeeFirstName = e.FirstName,
                    EmployeeLastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    EmployeesProjects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate == null
                            ? "not finished"
                            : p.Project.EndDate.ToString(),
                    })
                })
                .Take(10)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.EmployeeFirstName} {employee.EmployeeLastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.EmployeesProjects)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .Include(e => e.Employees)
                .Include(e => e.Town)
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    Count = a.Employees.Count(x => x.Address.AddressText == a.AddressText)
                })
                .OrderByDescending(e => e.Count)
                .ThenBy(e => e.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToArray();


            foreach (var address in addresses)
            {
                sb.AppendLine(
                    $"{address.AddressText}, {address.TownName} - {address.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // 09. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            int employeeId = 147;

            var employee = context.Employees
                .Where(e => e.EmployeeId == employeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.EmployeesProjects,
                    ProjectName = e.EmployeesProjects
                        .Where(p => p.EmployeeId == e.EmployeeId)
                        .Select(p => new
                        {
                            ProjectName = p.Project.Name
                        })
                        .OrderBy(p => p.ProjectName)
                        .ToList()
                })
                .FirstOrDefault();

            sb.AppendLine($"{employee?.FirstName} {employee?.LastName} - {employee?.JobTitle}");

            foreach (var project in employee!.ProjectName)
            {
                sb.AppendLine($"{project.ProjectName}");
            }

            return sb.ToString().TrimEnd();
        }

        // 10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(x => x.Name)
                .Include(x => x.Manager)
                .Include(x => x.Employees)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToList()
                })
                .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} – {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employeeInfo in department.Employees)
                {
                    sb.AppendLine($"{employeeInfo.FirstName} {employeeInfo.LastName} - {employeeInfo.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate.Date)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}\n{project.Description}\n{project.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        // 12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Include(e => e.Departments)
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        // 13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            string keyword = "SA";

            var employees = context.Employees
                //.Where(e => EF.Functions.Like(e.FirstName, $"{keyword}%"))
                .Where(e => e.FirstName.ToUpper().StartsWith(keyword))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        // 14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            int projectId = 2;

            var employeeProjects = context.EmployeesProjects
                .Where(p => p.ProjectId == projectId)
                .ToList();

            foreach (var employeeProject in employeeProjects)
            {
                context.EmployeesProjects.Remove(employeeProject);
            }

            context.SaveChanges();

            var project = context.Projects
                .Find(2);

            context.Projects
                .Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .ToList();

            foreach (var projectName in projects)
            {
                sb.AppendLine(projectName.Name);
            }

            return sb.ToString().TrimEnd();
        }

        // 15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            string cityName = "Seattle";

            var town = context.Towns
                .Include(e => e.Addresses)
                .FirstOrDefault(t => t.Name == cityName);

            var addresses = town!.Addresses
                .Select(a => a.AddressId)
                .ToList();

            var employees = context.Employees
                .Where(e => e.AddressId.HasValue && addresses
                    .Contains(e.AddressId.Value))
                .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            foreach (var address in addresses)
            {
                var addressToDelete = context.Addresses
                    .FirstOrDefault(a => a.AddressId == address);

                context.Addresses.Remove(addressToDelete!);
            }

            context.Towns.Remove(town!);

            context.SaveChanges();

            sb.AppendLine($"{addresses.Count} addresses in Seattle were deleted");

            return sb.ToString().TrimEnd();
        }
    }
}