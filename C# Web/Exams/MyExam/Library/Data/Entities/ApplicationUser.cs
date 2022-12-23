using Microsoft.AspNetCore.Identity;

namespace Library.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            ApplicationUsersBooks = new HashSet<ApplicationUserBook>();
        }

        public virtual ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; }
    }
}
