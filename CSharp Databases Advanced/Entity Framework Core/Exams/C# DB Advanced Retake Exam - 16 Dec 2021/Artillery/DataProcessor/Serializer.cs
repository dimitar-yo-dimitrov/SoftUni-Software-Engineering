namespace Artillery.DataProcessor
{
    using System.Linq;
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Artillery.DataProcessor.Helper;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context
                .Shells
                .ToList()
                .Where(shell => shell.ShellWeight > shellWeight)
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                        .Where(gun => gun.GunType.ToString() == "AntiAircraftGun")
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        })
                        .OrderByDescending(g => g.GunWeight)
                })
                .OrderBy(s => s.ShellWeight)
                .ToList();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            string rootName = "Guns";

            var guns = context
                .Guns
                .ToArray()
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(gun => new ExportGunDto
                {
                    Manufacturer = gun.Manufacturer.ManufacturerName,
                    GunType = gun.GunType.ToString(),
                    GunWeight = gun.GunWeight,
                    BarrelLength = gun.BarrelLength,
                    Range = gun.Range,
                    Countries = gun.CountriesGuns
                        .Where(cg => cg.Country.ArmySize > 4500000)
                        .Select(cg => new ExportCountryDto
                        {
                            Country = cg.Country.CountryName,
                            ArmySize = cg.Country.ArmySize
                        })
                        .OrderBy(c => c.ArmySize)
                        .ToArray()
                })
                .OrderBy(g => g.BarrelLength)
                .ToArray();

            return ConvertHelper.SerializeXml(guns, rootName);
        }
    }
}
