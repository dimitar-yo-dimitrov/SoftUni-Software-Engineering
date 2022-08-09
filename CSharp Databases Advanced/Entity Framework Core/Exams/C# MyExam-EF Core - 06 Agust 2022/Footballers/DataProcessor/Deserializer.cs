namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Artillery.DataProcessor.Helper;
    using Data;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootName = "Coaches";
            ImportCoachDto[] coachDtos =
                ConvertXml.DeserializeXml<ImportCoachDto[]>(xmlString, rootName);

            var coaches = new List<Coach>();

            foreach (var coachDto in coachDtos)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var footballer = new List<Footballer>();

                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime contractStartDate;

                    bool isContractStartDateValid =
                        DateTime.TryParseExact(
                            footballerDto.ContractStartDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out contractStartDate);

                    if (!isContractStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime contractEndDate;

                    bool isContractEndDateValid =
                        DateTime.TryParseExact(
                            footballerDto.ContractEndDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out contractEndDate);

                    if (!isContractEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validBestSkillType =
                        Enum.TryParse<BestSkillType>(footballerDto.BestSkillType, out var bestSkillType);

                    if (!validBestSkillType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    var validPositionType =
                        Enum.TryParse<PositionType>(footballerDto.PositionType, out var positionType);

                    if (!validPositionType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (contractStartDate >= contractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    footballer.Add(new Footballer
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = contractStartDate,
                        ContractEndDate = contractEndDate,
                        BestSkillType = bestSkillType,
                        PositionType = positionType
                    });
                }

                coaches.Add(new Coach
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                    Footballers = footballer
                });

                sb.AppendLine(String.Format(SuccessfullyImportedCoach, coachDto.Name, footballer.Count));
            }

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var teamDtos = JsonConvert.DeserializeObject<ImportTeamWithFootballerIdDto[]>(jsonString);

            ICollection<Team> validTeams = new List<Team>();


            foreach (var teamDto in teamDtos)
            {
                if (!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies
                };

                foreach (var footballerIdDto in teamDto.Footballers.Distinct())
                {
                    Footballer footballer = context.Footballers.Find(footballerIdDto);

                    if (footballer == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Team = team,
                        Footballer = footballer
                    });
                }

                validTeams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }

            context.Teams.AddRange(validTeams);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
