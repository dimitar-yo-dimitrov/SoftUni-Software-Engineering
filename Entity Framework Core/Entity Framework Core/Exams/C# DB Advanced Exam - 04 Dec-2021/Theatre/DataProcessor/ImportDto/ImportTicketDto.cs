using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Theatre.Data.Models;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject("Tickets")]
    public class ImportTicketDto
    {

        [Required]
        [Range(typeof(decimal), "1.00", "100.00")]
        [JsonProperty("Price")]
        public decimal Price { get; set; }


        [Required]
        [Range(1, 10)]
        [JsonProperty("RowNumber")]
        public sbyte RowNumber { get; set; }


        [Required]
        [ForeignKey(nameof(Play))]
        [JsonProperty("PlayId")]
        public int PlayId { get; set; }
    }
}
