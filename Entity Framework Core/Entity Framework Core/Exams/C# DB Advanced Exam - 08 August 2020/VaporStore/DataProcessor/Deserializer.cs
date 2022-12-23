namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Artillery.DataProcessor.Helper;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {

        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";


        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportGameDto[] gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            ICollection<Game> games = new List<Game>();
            ICollection<Developer> developers = new List<Developer>();
            ICollection<Genre> genres = new List<Genre>();
            ICollection<Tag> tags = new List<Tag>();

            foreach (var gameDto in gameDtos)
            {
                if (!ConvertXmlAndValidation.IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime releaseDate;

                bool isReleaseDateValid = DateTime.TryParseExact(
                    gameDto.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out releaseDate);

                if (!isReleaseDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate
                };

                Developer developer = developers
                    .FirstOrDefault(d => d.Name == gameDto.Developer);

                if (developer == null)
                {
                    Developer newDeveloper = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    developers.Add(newDeveloper);
                    game.Developer = newDeveloper;
                }
                else
                {
                    game.Developer = developer;
                }

                Genre genre = genres
                    .FirstOrDefault(g => g.Name == gameDto.Genre);

                if (genre == null)
                {
                    Genre newGenre = new Genre
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(newGenre);
                    game.Genre = newGenre;
                }
                else
                {
                    game.Genre = genre;
                }

                foreach (var tagName in gameDto.Tags)
                {
                    if (string.IsNullOrEmpty(tagName))
                    {
                        continue;
                    }

                    Tag tag = tags
                        .FirstOrDefault(t => t.Name == tagName);

                    if (tag == null)
                    {
                        Tag newTag = new Tag
                        {
                            Name = tagName
                        };

                        tags.Add(newTag);

                        game.GameTags.Add(new GameTag
                        {
                            Game = game,
                            Tag = newTag
                        });
                    }
                    else
                    {
                        game.GameTags.Add(new GameTag
                        {
                            Game = game,
                            Tag = tag
                        });
                    }
                }

                if (game.GameTags.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                games.Add(game);

                sb.AppendLine(String.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            List<User> users = new List<User>();

            foreach (ImportUserDto userDto in userDtos)
            {
                if (!ConvertXmlAndValidation.IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var userCards = new List<Card>();

                bool validCards = true;
                foreach (ImportUserCardDto cardDto in userDto.Cards)
                {
                    if (!ConvertXmlAndValidation.IsValid(cardDto))
                    {
                        validCards = false;
                        break;
                    }

                    bool isCardTypeValid =
                        Enum.TryParse(typeof(CardType), cardDto.Type, out var cardTypeObj);

                    if (!isCardTypeValid)
                    {
                        validCards = false;
                        break;
                    }

                    CardType cardType = (CardType)cardTypeObj!;

                    userCards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = cardType
                    });
                }

                if (!validCards)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (userCards.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = userCards
                };

                users.Add(user);
                sb.AppendLine(String.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootName = "Purchases";
            ImportPurchaseDto[] purchaseDtos =
                ConvertXmlAndValidation.DeserializeXml<ImportPurchaseDto[]>(xmlString, rootName);

            List<Purchase> purchases = new List<Purchase>();

            foreach (ImportPurchaseDto purchaseDto in purchaseDtos)
            {
                if (!ConvertXmlAndValidation.IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isPurchaseTypeValid =
                    Enum.TryParse(typeof(PurchaseType), purchaseDto.PurchaseType, out var purchaseTypeObj);

                if (!isPurchaseTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                PurchaseType purchaseType = (PurchaseType)purchaseTypeObj!;

                bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Card card = context
                    .Cards
                    .FirstOrDefault(c => c.Number == purchaseDto.CardNumber);

                if (card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = context
                    .Games
                    .FirstOrDefault(g => g.Name == purchaseDto.GameTitle);

                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase p = new Purchase()
                {
                    Type = purchaseType,
                    Date = date,
                    ProductKey = purchaseDto.Key,
                    Game = game,
                    Card = card
                };

                purchases.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedPurchase, p.Game.Name, p.Card.User.Username));
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
    }
}