using Newtonsoft.Json;

namespace CarDealer.DTO.Import
{
    [JsonObject]
    public class ImportSuppliersDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isImporter")]
        public bool IsImporter { get; set; }
    }
}
