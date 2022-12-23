using System.Collections.Generic;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.DTO.Export
{
    [JsonObject]
    public class ExportLocalSupplierDto
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }

        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(PartsCount))]
        public int PartsCount
        => Parts.Count;

        [JsonIgnore]
        public ICollection<Part> Parts { get; set; }
    }
}
