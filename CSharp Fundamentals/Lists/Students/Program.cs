using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace _04.Students
{

    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Hometown { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = words[0];
                string lastName = words[1];
                int age = int.Parse(words[2]);
                string hometown = words[3];

                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Hometown = hometown,
                };

                students.Add(student);
            }

            string city = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.Hometown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
}
