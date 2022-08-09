using System.ComponentModel.DataAnnotations;
using SoftJail.Common;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisonerMailDto
    {
        public string Description { get; set; }

        public string Sender { get; set; }

        [RegularExpression(ValidationConstants.PrisonerMailAddressRegex)]
        public string Address { get; set; }
    }
}
