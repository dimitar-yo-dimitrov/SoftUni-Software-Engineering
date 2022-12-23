using Newtonsoft.Json;

namespace CarDealer.DTO.Export
{
    [JsonObject]
    public class ExportSalesWithDiscountDto
    {
        [JsonProperty("car")]
        public ExportCarDto Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("Discount")]
        public string Discount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount
            => (decimal.Parse(this.Price) - decimal.Parse(this.Price) * decimal.Parse(this.Discount) / 100)
                .ToString("F2");
    }
}
