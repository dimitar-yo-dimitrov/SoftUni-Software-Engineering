namespace SoftJail.DataProcessor
{
    using System;
    using System.Linq;
    using Artillery.DataProcessor.Helper;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
             .Prisoners
             .ToArray()
             .Where(p => ids.Contains(p.Id))
             .Select(p => new
             {
                 Id = p.Id,
                 Name = p.FullName,
                 CellNumber = p.Cell.CellNumber,
                 Officers = p.PrisonerOfficers
                     .Select(op => new
                     {
                         OfficerName = op.Officer.FullName,
                         Department = op.Officer.Department.Name
                     })
                     .OrderBy(o => o.OfficerName)
                     .ToArray(),
                 TotalOfficerSalary = Math.Round(p.PrisonerOfficers
                     .Sum(op => op.Officer.Salary), 2)
             })
             .OrderBy(p => p.Name)
             .ThenBy(p => p.Id)
             .ToArray();

            return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string rootName = "Prisoners";

            var prisonersNamesArr = prisonersNames
                .Split(",")
                .ToArray();

            var prisoners = context
                .Prisoners
                .ToList()
                .Where(p => prisonersNamesArr.Contains(p.FullName))
                .Select(p => new ExportPrisonerWithMailsDto
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString(format: "yyyy-MM-dd"),
                    Mails = p.Mails
                        .Select(m => new ExportMailDescriptionDto
                        {
                            ReversedDescription = string.Join("", m.Description.Reverse())
                        })
                        .ToArray()
                })
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ToArray();

            return ConvertHelper.SerializeXml(prisoners, rootName);
        }
    }
}