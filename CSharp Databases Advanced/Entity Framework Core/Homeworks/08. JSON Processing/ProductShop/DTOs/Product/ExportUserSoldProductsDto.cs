namespace ProductShop.DTOs.Product
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ExportUserSoldProductsDto
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Price))]
        public decimal Price { get; set; }

        [JsonProperty(nameof(BuyerFirstName))]
        public string BuyerFirstName { get; set; }

        [JsonProperty(nameof(BuyerLastName))]
        public string BuyerLastName { get; set; }
    }
}