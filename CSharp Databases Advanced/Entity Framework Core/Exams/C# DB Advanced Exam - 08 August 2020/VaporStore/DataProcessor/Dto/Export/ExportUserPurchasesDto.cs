using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Purchase")]
    public class ExportUserPurchasesDto
    {
        [Required]
        [RegularExpression(@"^(\d{4})\s(\d{4})\s(\d{4})\s(\d{4})$")]
        [XmlElement("Card")]
        public string Card { get; set; }

        [Required]
        [RegularExpression(@"^(\d{3})$")]
        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlElement("Game")]
        public ExportGameDto Game { get; set; }
    }
}
