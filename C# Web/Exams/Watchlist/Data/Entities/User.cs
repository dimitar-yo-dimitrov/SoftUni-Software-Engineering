using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            UsersMovies = new HashSet<UserMovie>();
        }

        public virtual ICollection<UserMovie> UsersMovies { get; set; }
    }
}

