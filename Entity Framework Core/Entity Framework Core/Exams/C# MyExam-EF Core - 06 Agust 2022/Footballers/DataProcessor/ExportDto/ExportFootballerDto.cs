using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Footballer")]
    public class ExportFootballerDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public PositionType Position { get; set; }
    }
}
