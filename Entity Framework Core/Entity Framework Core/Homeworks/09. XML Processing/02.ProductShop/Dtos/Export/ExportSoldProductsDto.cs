using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class ExportSoldProductsDto
    {
        [XmlElement("count")]
        public int ProductsCount { get; set; }

        [XmlArray("products")]
        public ExportProductInfoDto[] Products { get; set; }
    }
}
