using System.ComponentModel.DataAnnotations;
using static Watchlist.Constants.ValidationConstants.GenreConstants;

namespace Watchlist.Data.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GenreMaxLength)]
        public string Name { get; set; } = null!;
    }
}


