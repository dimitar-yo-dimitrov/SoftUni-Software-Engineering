using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;

namespace Watchlist.Data.Entities
{
    public class UserMovie
    {
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; } = null!;
    }
}


