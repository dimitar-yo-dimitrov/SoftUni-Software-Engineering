using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2._0
{
    class Program
    {
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
        }
        static void Main(string[] args)
        {
            var students = new List<Student>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = parts[0];
                string lastName = parts[1];
                int age = int.Parse(parts[2]);
                string city = parts[3];

                if (ExistStudent(students, firstName, lastName))
                {
                    var student = GetStudent(students, firstName, lastName, age);
                }

                else
                {
                    var student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = city
                    };

                    students.Add(student);
                }
            }

            string filteredCity = Console.ReadLine();

            var filteredStudents = students
                .Where(s => s.City == filteredCity);

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

        static Student GetStudent(List<Student> students, string firstName, string lastName, int age)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (student.FirstName == firstName &&
                    student.LastName == lastName)
                {
                    existingStudent = student;
                    existingStudent.Age = age;
                }
            }

            return existingStudent;
        }

        static bool ExistStudent(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName &&
                    student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
