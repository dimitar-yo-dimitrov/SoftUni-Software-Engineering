using Newtonsoft.Json;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject("Countries")]
    public class ImportCountryIdDto
    {
        public int Id { get; set; }
    }
}
