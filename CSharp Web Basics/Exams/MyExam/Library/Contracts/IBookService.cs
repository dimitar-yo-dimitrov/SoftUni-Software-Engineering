using Library.Data.Entities;
using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllAsync();

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task AddBookAsync(AddBookViewModel model);

        Task AddBookToCollectionAsync(int bookId, string applicationUserId);

        Task<List<AllBookViewModel>> GetMyBookAsync(string userId);

        Task RemoveBookFromCollectionAsync(int bookId, string applicationUserId);
    }
}
