namespace BookShop
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Enums;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            //DbInitializer.ResetDatabase(context);

            //string command = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            //string input = Console.ReadLine();
            //string date = Console.ReadLine();
            //int lengthCheck = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine(RemoveBooks(context));

            // Problem 15
            //IncreasePrices(context);
        }

        // 02.Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            bool parseSuccess = Enum
                .TryParse(command, ignoreCase: true, out AgeRestriction ageRestriction);

            if (!parseSuccess)
            {
                return String.Empty;
            }

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }


        // 03.Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            int copies = 5000;

            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < copies)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        // 04.Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            decimal price = 40;

            var books = context.Books
                .Where(b => b.Price > price)
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 05.Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        // 06.Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Where(b => b.BookCategories
                    .Any(c => categories
                        .Contains(c.Category.Name.ToLower())))
                .Select(c => c.Title)
                .OrderBy(c => c)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        // 07.Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var dateTime = DateTime
                .ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < dateTime)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 08.Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => EF.Functions.Like(a.FirstName, $"%{input}"))
                //.Where(a => a.FirstName.EndsWith(input))
                .ToList()
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.FullName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName}");
            }

            return sb.ToString().TrimEnd();
        }

        // 09.Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => EF.Functions.Like(b.Title, $"%{input}%"))
                //.Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book}");
            }

            return sb.ToString().TrimEnd();
        }

        // 10.Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Select(b => new
                {
                    b.Author.FirstName,
                    b.Author.LastName,
                    b.Title,
                    b.BookId,
                })
                //.Where(a => EF.Functions.Like(a.LastName, $"{input}%"))
                .Where(a => a.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        // 11.Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            StringBuilder sb = new StringBuilder();

            var booksCount = context.Books
                .Count(b => b.Title.Length > lengthCheck);


            return booksCount;
        }

        // 12.Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}",
                    TotalBookCopies = a.Books.Sum(bc => bc.Copies)
                })
                .OrderByDescending(bc => bc.TotalBookCopies)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.TotalBookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        // 13.Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Categories
                .Select(bc => new
                {
                    CategoryName = bc.Name,
                    TotalProfit = bc.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(b => b.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToList();



            foreach (var book in books)
            {
                sb.AppendLine($"{book.CategoryName} ${book.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 14.Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Categories
                .Select(bc => new
                {
                    CategoryName = bc.Name,
                    BooksNameByCategory = bc.CategoryBooks
                        .Select(b => new
                        {
                            Title = b.Book.Title,
                            Date = b.Book.ReleaseDate
                        })
                        .OrderByDescending(b => b.Date)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"--{book.CategoryName}");

                foreach (var name in book.BooksNameByCategory)
                {
                    sb.AppendLine($"{name.Title} ({name.Date.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 15.Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            int year = 2010;
            decimal increaseBy = 5;

            //context.Books
            //    .Where(b => b.ReleaseDate.Value.Year < year)
            //    .Update(b => new Book() { Price = b.Price + increaseBy });

            IQueryable<Book> books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < year);

            foreach (Book book in books)
            {
                book.Price += increaseBy;
            }

            context.SaveChanges();
        }

        // 16.Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            int copies = 4200;

            var books = context.Books
                .Where(b => b.Copies < copies)
                .ToList();

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return books.Count;
        }
    }
}
