using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using ProductShop.Common;

namespace ProductShop.DTOs.Category
{
    [JsonObject]
    public class ImportCategoryDto
    {
        [Required]
        [MinLength(GlobalConstants.CategoryNameMinLength)]
        [MaxLength(GlobalConstants.CategoryNameMaxLength)]
        public string Name { get; set; }
    }
}
