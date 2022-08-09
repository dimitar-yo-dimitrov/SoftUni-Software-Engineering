using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    public class Student
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:F2}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Student student = new Student()
                {
                    FirstName = line[0],
                    SecondName = line[1],
                    Grade = double.Parse(line[2])
                };

                students.Add(student);
            }

            List<Student> sorted = students
                .OrderByDescending(x => x.Grade)
                .ToList();

            foreach (Student student in sorted)
            {
                Console.WriteLine(student);
            }
        }
    }
}
