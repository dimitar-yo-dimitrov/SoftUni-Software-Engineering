using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Contracts;
using Watchlist.Models;

namespace Watchlist.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ViewBag.Title = "All Movies";

            var model = await _movieService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddMovieViewModel model = new AddMovieViewModel()
            {
                Genres = await _movieService.GetGenresAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _movieService.AddMovieAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Invalid Operation!");

                return View(model);
            }
        }

        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId = User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await _movieService
                .AddMovieToCollectionAsync(movieId, userId!);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Watched()
        {
            var userId = User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await _movieService
                .GetWatchedAsync(userId!);

            return View("Watched", model);
        }

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await _movieService
                .RemoveMovieFromCollectionAsync(movieId, userId!);

            return RedirectToAction(nameof(Watched));
        }
    }
}
