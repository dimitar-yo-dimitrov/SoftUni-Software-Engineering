using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

using ProductShop.Common;

namespace ProductShop.DTOs.User
{
    [JsonObject]
    public class ImportUserDto
    {
        [JsonProperty(nameof(FirstName))]
        public string FirstName { get; set; }

        [JsonProperty(nameof(LastName))]
        [Required]
        [MinLength(GlobalConstants.UserLastNameMinLength)]
        public string LastName { get; set; }

        [JsonProperty(nameof(Age))]
        public int? Age { get; set; }
    }
}
