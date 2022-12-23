using Library.Contracts;
using Library.Data;
using Library.Data.Entities;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllAsync()
        {
            return await _context
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    Category = b.Category.Name,
                    Rating = b.Rating,
                    ImageUrl = b.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
            => await _context.Categories.ToListAsync();

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var entity = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId

            };

            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(int bookId, string applicationUserId)
        {
            var user = await _context.Users
                .Where(u => u.Id == applicationUserId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(u => u.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Invalid Book ID");
            }

            if (user.ApplicationUsersBooks.All(b => b.BookId != bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    BookId = book.Id,
                    ApplicationUserId = user.Id,
                    Book = book,
                    ApplicationUser = user
                });

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<AllBookViewModel>> GetMyBookAsync(string userId)
        {
            return await _context.Books
                .Where(b => b.ApplicationUsersBooks.Any(ub => ub.ApplicationUserId == userId))
                .Select(b => new AllBookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    Category = b.Category.Name,
                    Rating = b.Rating,
                    ImageUrl = b.ImageUrl
                })
                .ToListAsync();
        }

        public async Task RemoveBookFromCollectionAsync(int bookId, string applicationUserId)
        {

            var user = await _context.Users
                .Where(u => u.Id == applicationUserId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var book = user.ApplicationUsersBooks
                .FirstOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                user.ApplicationUsersBooks.Remove(book);

                await _context.SaveChangesAsync();
            }
        }
    }
}
