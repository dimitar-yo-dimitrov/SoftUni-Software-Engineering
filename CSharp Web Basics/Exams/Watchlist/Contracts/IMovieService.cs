using Watchlist.Data.Entities;
using Watchlist.Models;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MoviesViewModel>> GetAllAsync();

        Task<IEnumerable<Genre>> GetGenresAsync();

        Task AddMovieAsync(AddMovieViewModel model);

        Task AddMovieToCollectionAsync(int movieId, string userId);

        Task<IEnumerable<MoviesViewModel>> GetWatchedAsync(string userId);

        Task RemoveMovieFromCollectionAsync(int movieId, string userId);
    }
}
