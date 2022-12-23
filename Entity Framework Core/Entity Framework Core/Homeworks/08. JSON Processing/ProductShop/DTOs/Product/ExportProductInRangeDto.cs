using Newtonsoft.Json;

namespace ProductShop.DTOs.Product
{
    [JsonObject]
    public class ExportProductInRangeDto
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Price))]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string SellerFullName { get; set; }
    }
}
