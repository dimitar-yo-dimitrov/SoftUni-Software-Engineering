using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using P01_StudentSystem.Data.Common;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.StudentsEnrolled = new HashSet<StudentCourse>();
            this.Resources = new HashSet<Resource>();
            this.HomeworkSubmissions = new HashSet<Homework>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(GlobalConstants.CourseNameMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        // One course can have many StudentsEnrolled
        public virtual ICollection<StudentCourse> StudentsEnrolled { get; set; }

        // One course can have many Resources
        public virtual ICollection<Resource> Resources { get; set; }

        // One course can have many HomeworkSubmissions
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}

