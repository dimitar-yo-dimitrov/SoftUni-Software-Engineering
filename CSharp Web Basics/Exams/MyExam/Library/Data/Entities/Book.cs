using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static Library.Constants.ValidationConstants.BookConstants;

namespace Library.Data.Entities
{
    public class Book
    {
        public Book()
        {
            ApplicationUsersBooks = new HashSet<ApplicationUserBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        public decimal Rating { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public int? CategoryId { get; set; }

        [Required]
        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; }
    }
}
