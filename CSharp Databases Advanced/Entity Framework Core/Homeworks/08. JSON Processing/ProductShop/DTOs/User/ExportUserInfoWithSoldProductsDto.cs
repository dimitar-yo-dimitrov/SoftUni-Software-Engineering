using Newtonsoft.Json;

namespace ProductShop.DTOs.User
{
    [JsonObject]
    public class ExportUserInfoWithSoldProductsDto
    {
        [JsonProperty(nameof(FirstName))]
        public string FirstName { get; set; }

        [JsonProperty(nameof(LastName))]
        public string LastName { get; set; }

        [JsonProperty(nameof(Age))]
        public int? Age { get; set; }

        [JsonProperty(nameof(SoldProducts))]
        public ExportUserInfoDto[] SoldProducts { get; set; }
    }
}
