namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Artillery.DataProcessor.Helper;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var gamesByGenres = context
                .Genres
                .Where(g => genreNames.Contains(g.Name))
                .ToArray()
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                        .Where(game => game.Purchases.Any())
                        .Select(gm => new
                        {
                            Id = gm.Id,
                            Title = gm.Name,
                            Developer = gm.Developer.Name,
                            Tags = String.Join(", ", gm.GameTags
                                .Select(gt => gt.Tag.Name)
                                .ToArray()),
                            Players = gm.Purchases.Count
                        })
                        .OrderByDescending(gm => gm.Players)
                        .ThenBy(gm => gm.Id)
                        .ToArray(),
                    TotalPlayers = g.Games.Sum(gm => gm.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            return JsonConvert.SerializeObject(gamesByGenres, Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            string rootName = "Users";

            PurchaseType purchaseTypeEnum = Enum.Parse<PurchaseType>(storeType);

            var users = context
                .Users
                .ToArray()
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .Select(u => new ExportUserDto
                {
                    UserName = u.Username,
                    Purchases = context
                        .Purchases
                        .ToArray()
                        .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                        .OrderBy(p => p.Date)
                        .Select(p => new ExportUserPurchasesDto
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString(format: "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .ToArray(),
                    TotalSpent = context
                        .Purchases
                        .ToArray()
                        .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                        .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Length > 0)
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.UserName)
                .ToArray();

            return ConvertXmlAndValidation.SerializeXml(users, rootName);
        }
    }
}