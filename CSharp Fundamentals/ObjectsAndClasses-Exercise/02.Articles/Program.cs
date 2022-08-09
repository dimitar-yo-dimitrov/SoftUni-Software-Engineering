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

            int n = int.Parse(Console.ReadLine());

            Article article = new Article()
            {
                Title = articleData[0],
                Content = articleData[1],
                Author = articleData[2]
            };

            for (int i = 0; i < n; i++)
            {
                string[] commandParts = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string firstCommand = commandParts[0];
                string secondCommand = commandParts[1];

                if (firstCommand == "Edit")
                {
                    article.Edit(secondCommand);
                }

                else if (firstCommand == "ChangeAuthor")
                {
                    article.ChangeAuthor(secondCommand);
                }

                else if (firstCommand == "Rename")
                {
                    article.Rename(secondCommand);
                }
            }

            Console.WriteLine(article);
        }
    }
}
