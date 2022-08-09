using System.ComponentModel.DataAnnotations;
using SoftJail.Common;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentWithCellsDto
    {
        [MinLength(ValidationConstants.DepartmentNameMinLength)]
        [MaxLength(ValidationConstants.DepartmentNameMaxLength)]
        public string Name { get; set; }

        public virtual ImportDepartmentCellDto[] Cells { get; set; }
    }
}
