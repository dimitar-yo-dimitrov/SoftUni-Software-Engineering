namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Artillery.DataProcessor.Helper;
    using AutoMapper;
    using Newtonsoft.Json;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootName = "Plays";
            ImportPlayDto[] playDtos =
                ConvertHelper.DeserializeXml<ImportPlayDto[]>(xmlString, rootName);

            ICollection<Play> validPlays = new List<Play>();

            foreach (var playDto in playDtos)
            {
                if (!ConvertHelper.IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validDuration = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture);
                if (validDuration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validGenre = Enum.TryParse<Genre>(playDto.Genre, out var genre);
                if (!validGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = Mapper.Map<Play>(playDto);
                validPlays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay, playDto.Title, playDto.Genre, playDto.Rating));
            }

            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootName = "Casts";
            ImportCastDto[] castDtos =
                ConvertHelper.DeserializeXml<ImportCastDto[]>(xmlString, rootName);

            ICollection<Cast> validCasts = new List<Cast>();

            foreach (var castDto in castDtos)
            {
                if (!ConvertHelper.IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Cast cast = Mapper.Map<Cast>(castDto);
                validCasts.Add(cast);
                sb.AppendLine(string.Format(SuccessfulImportActor, castDto.FullName, castDto.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportTheatreDto[] theatreDtos = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            ICollection<Theatre> validTheatres = new List<Theatre>();

            foreach (var theatreDto in theatreDtos)
            {
                if (!ConvertHelper.IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var tickets = new List<Ticket>();

                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!ConvertHelper.IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    tickets.Add(new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    });
                }

                validTheatres.Add(new Theatre
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director,
                    Tickets = tickets
                });
                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatreDto.Name, tickets.Count));
            }

            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
    }
}
