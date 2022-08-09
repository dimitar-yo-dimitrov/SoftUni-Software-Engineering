using Newtonsoft.Json;

namespace ProductShop.DTOs.CategoryProduct
{
    [JsonObject]
    public class ImportCategoryProductDto
    {
        [JsonProperty(nameof(CategoryId))]
        public int CategoryId { get; set; }

        [JsonProperty(nameof(ProductId))]
        public int ProductId { get; set; }
    }
}
