using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static Watchlist.Constants.ValidationConstants.MovieConstants;

namespace Watchlist.Data.Entities
{
    public class Movie
    {
        public Movie()
        {
            UsersMovies = new HashSet<UserMovie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DirectorMaxLength)]
        public string Director { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        public decimal Rating { get; set; }

        [ForeignKey(nameof(Genre))]
        public int? GenreId { get; set; }

        [Required]
        public virtual Genre? Genre { get; set; }

        public virtual ICollection<UserMovie> UsersMovies { get; set; }
    }
}
