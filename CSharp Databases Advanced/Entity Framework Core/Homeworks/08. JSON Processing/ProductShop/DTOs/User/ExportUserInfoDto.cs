using System.Linq;

using Newtonsoft.Json;

namespace ProductShop.DTOs.User
{
    [JsonObject]
    public class ExportUserInfoDto
    {
        [JsonProperty(nameof(UsersCount))]
        public int UsersCount
            => this.Users.Any() ? this.Users.Length : 0;

        [JsonProperty(nameof(Users))]
        public ExportUserInfoWithSoldProductsDto[] Users { get; set; }
    }
}
