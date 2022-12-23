using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using SoftJail.Common;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficerDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(ValidationConstants.OfficerFullNameMinLength)]
        [MaxLength(ValidationConstants.OfficerFullNameMaxLength)]
        public string FullName { get; set; }

        [XmlElement("Money")]
        [Range(typeof(decimal),
            ValidationConstants.OfficerMinSalary, ValidationConstants.OfficerMaxSalary)]
        public decimal Salary { get; set; }

        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }

        [Required]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public virtual ImportPrisonerDto[] Prisoners { get; set; }
    }
}
