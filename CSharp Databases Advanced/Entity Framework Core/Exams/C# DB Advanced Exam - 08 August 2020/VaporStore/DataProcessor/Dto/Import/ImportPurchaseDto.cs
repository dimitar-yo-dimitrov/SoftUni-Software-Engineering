namespace VaporStore.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [Required]
        [XmlElement("Type")]
        public string PurchaseType { get; set; }

        [Required]
        [RegularExpression(@"^([A-Z0-9]{4})\-([A-Z0-9]{4})\-([A-Z0-9]{4})$")]
        [XmlElement("Key")]
        public string Key { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }

        [Required]
        [RegularExpression(@"^(\d{4})\s(\d{4})\s(\d{4})\s(\d{4})$")]
        [XmlElement("Card")]
        public string CardNumber { get; set; }

        [Required]
        [XmlAttribute("title")]
        public string GameTitle { get; set; }
    }
}