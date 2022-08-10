using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGameDto
    {
        [Required]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }

        [Required]
        [JsonProperty("Developer")]
        public string Developer { get; set; }

        [Required]
        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Tags")]
        public virtual string[] Tags { get; set; }
    }
}
