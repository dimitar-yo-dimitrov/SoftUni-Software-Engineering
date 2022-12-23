using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

using ProductShop.Common;

namespace ProductShop.DTOs.Product
{
    [JsonObject]
    public class ImportProductDto
    {
        [JsonProperty(nameof(Name))]
        [Required]
        [MinLength(GlobalConstants.ProductNameMinLength)]
        public string Name { get; set; }

        [JsonProperty(nameof(Price))]
        public decimal Price { get; set; }

        [JsonProperty(nameof(SellerId))]
        public int SellerId { get; set; }

        [JsonProperty(nameof(BuyerId))]
        public int? BuyerId { get; set; }
    }
}
