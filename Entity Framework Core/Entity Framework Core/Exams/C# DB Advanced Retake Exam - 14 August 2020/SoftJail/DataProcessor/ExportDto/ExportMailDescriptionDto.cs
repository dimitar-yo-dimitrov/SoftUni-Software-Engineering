using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class ExportMailDescriptionDto
    {
        [XmlElement("Description")]
        public string ReversedDescription { get; set; }
    }
}
