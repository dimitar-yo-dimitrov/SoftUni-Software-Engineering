namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.Helper;
    using Artillery.DataProcessor.ImportDto;

    using AutoMapper;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootName = "Countries";
            ImportCountryDto[] countryDtos =
                ConvertHelper.DeserializeXml<ImportCountryDto[]>(xmlString, rootName);

            ICollection<Country> validCoutries = new List<Country>();

            foreach (ImportCountryDto cDto in countryDtos)
            {
                if (!ConvertHelper.IsValid(cDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                sb.AppendLine(string.Format(SuccessfulImportCountry, cDto.CountryName, cDto.ArmySize));
                Country country = Mapper.Map<Country>(cDto);
                validCoutries.Add(country);
            }

            context.Countries.AddRange(validCoutries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootName = "Manufacturers";
            ImportManufacturerDto[] manufacturerDtos =
                ConvertHelper.DeserializeXml<ImportManufacturerDto[]>(xmlString, rootName);

            ICollection<Manufacturer> validManufacturers = new List<Manufacturer>();

            foreach (ImportManufacturerDto mDto in manufacturerDtos)
            {
                if (!ConvertHelper.IsValid(mDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validManufacturers.Any(m => m.ManufacturerName == mDto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer
                {
                    ManufacturerName = mDto.ManufacturerName,
                    Founded = mDto.Founded
                };

                var foundedLocation = mDto
                    .Founded
                    .Split(", ")
                    .TakeLast(2)
                    .ToArray();

                sb.AppendLine(string.Format(SuccessfulImportManufacturer,
                    mDto.ManufacturerName, $"{foundedLocation[0]}, {foundedLocation[1]}"));

                //sb.AppendLine(String.Format(SuccessfulImportManufacturer,
                //    mDto.ManufacturerName, $"{string.Join(", ", mDto.Founded.Split(", ").TakeLast(2))}"));

                validManufacturers.Add(manufacturer);
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootName = "Shells";
            ImportShellDto[] shellDtos =
                ConvertHelper.DeserializeXml<ImportShellDto[]>(xmlString, rootName);

            ICollection<Shell> validShells = new List<Shell>();

            foreach (ImportShellDto shellDto in shellDtos)
            {
                if (!ConvertHelper.IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                sb.AppendLine(string.Format(SuccessfulImportShell, shellDto.Caliber, shellDto.ShellWeight));
                Shell shell = Mapper.Map<Shell>(shellDto);
                validShells.Add(shell);
            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportGunDto[] gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

            ICollection<Gun> validGuns = new List<Gun>();

            foreach (ImportGunDto gunDto in gunDtos)
            {
                if (!ConvertHelper.IsValid(gunDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                GunType gunTypeObj;
                bool isGunTypeValid = Enum.TryParse(gunDto.GunType, out gunTypeObj);

                if (!isGunTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun()
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = gunTypeObj,
                    ShellId = gunDto.ShellId,
                    CountriesGuns = gunDto.Countries.Select(c => new CountryGun
                    {
                        CountryId = c.Id
                    })
                        .ToList()
                };

                validGuns.Add(gun);

                sb.AppendLine(string.Format(
                    SuccessfulImportGun, gunDto.GunType, gunDto.GunWeight, gunDto.BarrelLength));
            }

            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
    }
}
