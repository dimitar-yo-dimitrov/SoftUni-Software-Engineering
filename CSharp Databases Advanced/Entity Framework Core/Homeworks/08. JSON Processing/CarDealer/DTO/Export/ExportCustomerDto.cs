using System;
using Newtonsoft.Json;

namespace CarDealer.DTO.Export
{
    [JsonObject]
    public class ExportCustomerDto
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(BirthDate))]
        public DateTime BirthDate { get; set; }

        [JsonProperty(nameof(IsYoungDriver))]
        public bool IsYoungDriver { get; set; }
    }
}
