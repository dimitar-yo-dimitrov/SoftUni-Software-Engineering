using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Data.Common;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.CourseEnrollments = new HashSet<StudentCourse>();
            this.HomeworkSubmissions = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.StudentNameMaxLength)]
        public string Name { get; set; }

        [Column(TypeName = GlobalConstants.PhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        // One student can have many CourseEnrollments
        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; }

        // One student can have many HomeworkSubmissions
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }



    }
}


