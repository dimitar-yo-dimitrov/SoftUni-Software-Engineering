using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SoftJail.Common;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportPrisonerWithMailsDto
    {
        [Required]
        [MinLength(ValidationConstants.PrisonerFullNameMinLength)]
        [MaxLength(ValidationConstants.PrisonerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.PrisonerNicknameRegex)]
        public string Nickname { get; set; }

        [Range(ValidationConstants.PrisonerMinAge, ValidationConstants.PrisonerMaxAge)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(typeof(decimal),
            ValidationConstants.PrisonerMinBail, ValidationConstants.PrisonerMaxBail)]
        public decimal? Bail { get; set; }

        [ForeignKey(nameof(Cell))]
        public int? CellId { get; set; }
        public virtual Cell Cell { get; set; }

        public virtual ImportPrisonerMailDto[] Mails { get; set; }
    }
}
