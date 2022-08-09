using System;

namespace _02.Articles
{
    public class Article
    {
        public string Title { get; set; }
      
        public string Content { get; set; }
        
        public string Author { get; set; }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Article article = new Article()
            {
                Title = articleData[0],
                Content = articleData[1],
                Author = articleData[2]
            };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] comandParts = Console.ReadLine()
                    .Split(": ");

                string firstComand = comandParts[0];
                string secondComand = comandParts[1];

                if (firstComand == "Edit")
                {
                    article.Edit(secondComand);
                }
                else if (firstComand == "ChangeAuthor")
                {
                    article.ChangeAuthor(secondComand);
                }
                else
                {
                    article.Rename(secondComand);
                }
            }

            Console.WriteLine(article);
        }
    }
}
