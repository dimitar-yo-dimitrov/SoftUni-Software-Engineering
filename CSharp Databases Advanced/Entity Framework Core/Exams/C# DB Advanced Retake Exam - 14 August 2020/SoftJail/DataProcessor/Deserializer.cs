namespace SoftJail.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Artillery.DataProcessor.Helper;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data";
        private const string SuccessfulImportDepartment =
            "Imported {0} with {1} cells";
        private const string SuccessfulImportPrisonersAndMails =
            "Imported {0} {1} years old";
        private const string SuccessfulImportImportOfficersAndPrisoners =
            "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var departmentDtos =
                JsonConvert.DeserializeObject<ImportDepartmentWithCellsDto[]>(jsonString);

            ICollection<Department> validDepartments = new List<Department>();

            foreach (var dDto in departmentDtos)
            {
                if (!ConvertHelper.IsValid(dDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department
                {
                    Name = dDto.Name
                };

                bool isValidDepartment = true;

                foreach (var cellDto in dDto.Cells)
                {
                    if (!ConvertHelper.IsValid(cellDto))
                    {
                        isValidDepartment = false;
                        break;
                    }

                    department.Cells.Add(new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }

                if (!isValidDepartment)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (department.Cells.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validDepartments.Add(department);

                sb.AppendLine(string.Format(SuccessfulImportDepartment,
                    department.Name, department.Cells.Count));
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {

            StringBuilder sb = new StringBuilder();

            var prisonerDtos =
                JsonConvert.DeserializeObject<ImportPrisonerWithMailsDto[]>(jsonString);

            ICollection<Prisoner> validPrisoners = new List<Prisoner>();

            foreach (var pDto in prisonerDtos)
            {
                if (!ConvertHelper.IsValid(pDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;
                bool isIncarcerationDateValid =
                    DateTime.TryParseExact(
                        pDto.IncarcerationDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? releaseDate = null;
                if (!string.IsNullOrEmpty(pDto.ReleaseDate))
                {
                    DateTime releaseDateValue;
                    bool isReleaseDateValid =
                        DateTime.TryParseExact(
                            pDto.ReleaseDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                Prisoner prisoner = new Prisoner
                {
                    FullName = pDto.FullName,
                    Nickname = pDto.Nickname,
                    Age = pDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = pDto.Bail,
                    CellId = pDto.CellId
                };

                bool isMailValid = true;

                foreach (var mailDto in pDto.Mails)
                {
                    if (!ConvertHelper.IsValid(mailDto))
                    {
                        isMailValid = false;
                        continue;
                    }

                    prisoner.Mails.Add(new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    });
                }

                if (!isMailValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validPrisoners.Add(prisoner);
                sb.AppendLine(string.Format(SuccessfulImportPrisonersAndMails, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootName = "Officers";
            ImportOfficerDto[] officerDtos =
                ConvertHelper.DeserializeXml<ImportOfficerDto[]>(xmlString, rootName);

            ICollection<Officer> validOfficers = new List<Officer>();

            foreach (ImportOfficerDto oDto in officerDtos)
            {
                if (!ConvertHelper.IsValid(oDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Position positionObj;
                bool isPositionValid = Enum.TryParse(oDto.Position, out positionObj);

                if (!isPositionValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Weapon weaponObj;
                bool isWeaponValid = Enum.TryParse(oDto.Weapon, out weaponObj);

                if (!isWeaponValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Officer officer = new Officer
                {
                    FullName = oDto.FullName,
                    Salary = oDto.Salary,
                    Position = positionObj,
                    Weapon = weaponObj,
                    DepartmentId = oDto.DepartmentId,
                };

                foreach (var prisonerDto in oDto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        Officer = officer,
                        PrisonerId = prisonerDto.PrisonerId
                    });
                }

                validOfficers.Add(officer);
                sb.AppendLine(string.Format(
                    SuccessfulImportImportOfficersAndPrisoners, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
    }
}