using System.ComponentModel.DataAnnotations;
using static Library.Constants.ValidationConstants.CategoryConstants;

namespace Library.Data.Entities
{
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
