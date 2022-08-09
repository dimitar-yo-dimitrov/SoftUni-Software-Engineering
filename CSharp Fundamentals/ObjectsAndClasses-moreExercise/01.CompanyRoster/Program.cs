using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster
{
    public class Employee
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();
            List<string> departments = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = parts[0];
                decimal salary = decimal.Parse(parts[1]);
                string department = parts[2];

                Employee employee = new Employee
                {
                    Name = name,
                    Salary = salary,
                    Department = department
                };

                employees.Add(employee);
                departments.Add(department);
            }

            string departmentHighestAverage = String.Empty;
            decimal highestAverageSalary = decimal.MinValue;

            foreach (var department in departments)
            {
                decimal averageSalaryByDepartment = CalcAverageSalaryByDepartment(employees, department);

                if (averageSalaryByDepartment > highestAverageSalary)
                {
                    departmentHighestAverage = department;
                    highestAverageSalary = averageSalaryByDepartment;
                }
            }

            Console.WriteLine($"Highest Average Salary: {departmentHighestAverage}");

            var sorted = employees
                .Where(e => e.Department == departmentHighestAverage)
                .OrderByDescending(e => e.Salary);

            foreach (var employee in sorted)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }

        private static decimal CalcAverageSalaryByDepartment(List<Employee> employees, string department)
        {
            int countOfDepartment = 0;
            decimal totalSalary = 0;

            foreach (var employee in employees)
            {
                if (employee.Department == department)
                {
                    countOfDepartment++;
                    totalSalary += employee.Salary;
                }
            }

            return totalSalary / countOfDepartment;
        }
    }
}
