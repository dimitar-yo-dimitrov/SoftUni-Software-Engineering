using System.ComponentModel.DataAnnotations;
using SoftJail.Common;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentCellDto
    {
        [Range(ValidationConstants.CellMinRange, ValidationConstants.CellMaxRange)]
        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }
    }
}
