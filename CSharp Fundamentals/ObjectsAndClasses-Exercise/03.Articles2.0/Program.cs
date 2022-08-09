using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    public class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                Article article = new Article()
                {
                    Title = line[0],
                    Content = line[1],
                    Author = line[2]
                };

                articles.Add(article);
            }

            string sortingCommand = Console.ReadLine();

            List<Article> sorted = new List<Article>();

            if (sortingCommand == "title")
            {
                sorted = articles
                    .OrderBy(x => x.Title)
                    .ToList();
            }

            else if (sortingCommand == "content")
            {
                sorted = articles
                    .OrderBy(x => x.Content)
                    .ToList();
            }

            else if (sortingCommand == "author")
            {
                sorted = articles
                    .OrderBy(x => x.Author)
                    .ToList();
            }

            foreach (Article article in sorted)
            {
                Console.WriteLine(article);
            }
        }
    }
}
