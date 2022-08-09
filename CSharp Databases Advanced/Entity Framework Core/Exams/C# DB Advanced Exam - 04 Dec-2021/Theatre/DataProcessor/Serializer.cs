using System.Globalization;
using System.Linq;
using Artillery.DataProcessor.Helper;
using Newtonsoft.Json;
using Theatre.DataProcessor.ExportDto;

namespace Theatre.DataProcessor
{
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context
                .Theatres
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls)
                .Where(t => t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                        .Sum(tc => tc.Price),
                    Tickets = t.Tickets
                        .Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                        .Select(tc => new
                        {
                            Price = tc.Price,
                            RowNumber = tc.RowNumber
                        })
                        .OrderByDescending(tc => tc.Price)
                        .ToList()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToList();

            return JsonConvert.SerializeObject(theaters, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            string rootName = "Plays";

            var plays = context
                .Plays
                .ToList()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(CultureInfo.InvariantCulture),
                    Genre = p.Genre,
                    Actors = p.Casts
                        .Where(a => a.IsMainCharacter)
                        .Select(c => new ExportActorDto
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToList();

            return ConvertHelper.SerializeXml(plays, rootName);
        }
    }
}
