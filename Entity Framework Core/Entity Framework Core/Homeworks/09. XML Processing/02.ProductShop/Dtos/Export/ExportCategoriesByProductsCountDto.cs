using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Category")]
    public class ExportCategoriesByProductsCountDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int NumberOfProducts { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePriceOfProducts { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalPriceSum { get; set; }
    }
}
