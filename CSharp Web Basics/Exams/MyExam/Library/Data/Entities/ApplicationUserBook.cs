using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class ApplicationUserBook
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; } = null!;
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public virtual Book Book { get; set; } = null!;
    }
}
