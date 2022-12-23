using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [StringLength(GlobalConstants.ResourceNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ResourceMaxLengthUrl)]
        public string Url { get; set; }

        [Required]
        public ResourceTypeEnum ResourceType { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

    }
}

