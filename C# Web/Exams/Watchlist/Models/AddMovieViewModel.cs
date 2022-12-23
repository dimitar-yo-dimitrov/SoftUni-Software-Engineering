using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Entities;
using static Watchlist.Constants.ValidationConstants.MovieConstants;

namespace Watchlist.Models
{
    public class AddMovieViewModel
    {
        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = "The field {0} must have a minimum length of {2} and a maximum length of {1}!")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "The field {0} is required!")]
        [StringLength(DirectorMaxLength,
            MinimumLength = DirectorMinLength,
            ErrorMessage = "The field {0} must have a minimum length of {2} and a maximum length of {1}!")]
        public string Director { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), RatingMinLength, RatingMaxLength, ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}
