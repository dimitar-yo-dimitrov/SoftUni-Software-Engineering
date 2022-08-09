using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    public class Student
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public float Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:f2}";
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
                    Grade = float.Parse(line[2])
                };

                students.Add(student);
            }

            var sorted = students
                .OrderByDescending(x => x.Grade);

            foreach (Student student in sorted)
            {
                Console.WriteLine(student);
            }
        }
    }
}
