using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Entities;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext _context;

        public MovieService(WatchlistDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MoviesViewModel>> GetAllAsync()
        {
            return await _context
                .Movies
                .Select(m => new MoviesViewModel()
                {
                    Director = m.Director,
                    Genre = m.Genre!.Name,
                    Id = m.Id,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Title = m.Title
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var entity = new Movie
            {
                Director = model.Director,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Title = model.Title
            };

            await _context.Movies.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = await _context.Movies.FirstOrDefaultAsync(u => u.Id == movieId);

            if (movie == null)
            {
                throw new ArgumentException("Invalid Movie ID");
            }

            if (user.UsersMovies.All(m => m.MovieId != movieId))
            {
                user.UsersMovies.Add(new UserMovie()
                {
                    MovieId = movie.Id,
                    UserId = user.Id,
                    Movie = movie,
                    User = user
                });

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MoviesViewModel>> GetWatchedAsync(string userId)
        {
            return await _context
                .Movies
                .Where(m => m.UsersMovies.Any(um => um.UserId == userId))
                .Select(m => new MoviesViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m.Genre!.Name
                })
                .ToListAsync();
        }

        public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = user.UsersMovies.FirstOrDefault(m => m.MovieId == movieId);

            if (movie != null)
            {
                user.UsersMovies.Remove(movie);

                await _context.SaveChangesAsync();
            }
        }
    }
}
