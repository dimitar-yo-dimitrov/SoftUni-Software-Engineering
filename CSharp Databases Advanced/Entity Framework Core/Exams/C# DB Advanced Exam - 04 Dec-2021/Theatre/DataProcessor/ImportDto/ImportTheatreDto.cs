using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreDto
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        [JsonProperty("Name")]
        public string Name { get; set; }


        [Required]
        [Range(1, 10)]
        [JsonProperty("NumberOfHalls")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Tickets")]
        public virtual ICollection<ImportTicketDto> Tickets { get; set; }
    }
}
