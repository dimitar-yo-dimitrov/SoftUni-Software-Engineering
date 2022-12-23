﻿using Newtonsoft.Json;

namespace CarDealer.DTO.Export
{
    [JsonObject]
    public class ExportCarToyotaDto
    {
        [JsonProperty(nameof(Id))]
        public int Id { get; set; }

        [JsonProperty(nameof(Make))]
        public string Make { get; set; }

        [JsonProperty(nameof(Model))]
        public string Model { get; set; }

        [JsonProperty(nameof(TravelledDistance))]
        public long TravelledDistance { get; set; }
    }
}
