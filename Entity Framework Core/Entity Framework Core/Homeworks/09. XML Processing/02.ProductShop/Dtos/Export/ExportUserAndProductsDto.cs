using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class ExportUserAndProductsDto
    {
        [XmlElement("count")]
        public int CountOfUsers { get; set; }

        [XmlArray("users")]
        public ExportUserWithProductsDto[] Users { get; set; }
    }
}
