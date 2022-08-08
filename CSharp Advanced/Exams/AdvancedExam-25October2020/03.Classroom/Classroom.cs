using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            Students = new List<Student>();
            Capacity = capacity;
        }

        //•	Capacity: int
        //•	Count: int – returns the number of students in the classroom

        public List<Student> Students { get; set; }

        public int Count => Students.Count;

        public int Capacity { get; set; }

        public string RegisterStudent(Student student)
        {
            if (Students.Count < Capacity)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student removesStudent = Students
                .FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (removesStudent == null)
            {
                return "Student not found";
            }

            Students.Remove(removesStudent);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            bool isFound = false;

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in Students)
            {
                if (student.Subject == subject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                    isFound = true;
                }
            }

            if (isFound) return sb.ToString().TrimEnd();

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount() => Students.Count;

        public Student GetStudent(string firstName, string lastName) => 
            Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

    }
}
