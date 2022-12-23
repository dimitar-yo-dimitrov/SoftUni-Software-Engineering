﻿using System.ComponentModel.DataAnnotations;
using static Library.Constants.ValidationConstants.BookConstants;

namespace Library.Models
{
    public class AllBookViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = "The field {0} must have a minimum length of {2} and a maximum length of {1}!")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(AuthorMaxLength,
            MinimumLength = AuthorMinLength,
            ErrorMessage = "The field {0} must have a minimum length of {2} and a maximum length of {1}!")]
        public string Author { get; set; } = null!;

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = "The field {0} must have a minimum length of {2} and a maximum length of {1}!")]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), RatingMinLength, RatingMaxLength, ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public string? Category { get; set; } = null!;
    }
}
