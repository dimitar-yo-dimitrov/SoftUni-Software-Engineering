using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MusicHub.Common;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.AlbumNameLengthMin)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        // Price – calculated property(the sum of all song prices in the album, NOT IN DB)
        [NotMapped]
        public decimal Price
            => this.Songs.Count > 0
                ? this.Songs.Sum(s => s.Price)
                : 0m;

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }
        public virtual Producer Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}

