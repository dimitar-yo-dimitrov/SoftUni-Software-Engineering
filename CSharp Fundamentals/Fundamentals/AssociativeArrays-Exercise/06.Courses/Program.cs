using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string courseName = parts[0];
                string studentName = parts[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(studentName);
            }

            var sorted = courses
                .OrderByDescending(c => c.Value.Count);

            foreach (var course in sorted)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                course.Value.Sort();

                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
