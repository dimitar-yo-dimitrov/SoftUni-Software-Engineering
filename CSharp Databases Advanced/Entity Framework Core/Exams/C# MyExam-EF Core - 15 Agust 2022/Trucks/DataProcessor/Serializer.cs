namespace Trucks.DataProcessor
{
    using System.Linq;
    using Artillery.DataProcessor.Helper;
    using Data;
    using Newtonsoft.Json;
    using Trucks.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            string rootName = "Despatchers";

            var despatchers = context
                .Despatchers
                .ToArray()
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatcherWithTrucksDto
                {
                    TrucksCount = d.Trucks.Count,
                    DespatcherName = d.Name,
                    Trucks = d.Trucks
                        .Select(t => new ExportTruckDto
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            MakeType = t.MakeType.ToString(),
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToArray()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            return ConvertXml.SerializeXml(despatchers, rootName);
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context
                .Clients
                .ToList()
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .Select(ct => new
                        {
                            TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                            VinNumber = ct.Truck.VinNumber,
                            TankCapacity = ct.Truck.TankCapacity,
                            CargoCapacity = ct.Truck.CargoCapacity,
                            CategoryType = ct.Truck.CategoryType.ToString(),
                            MakeType = ct.Truck.MakeType.ToString()
                        })
                        .OrderBy(ct => ct.MakeType)
                        .ThenByDescending(ct => ct.CargoCapacity)
                        .ToList()

                })
                .OrderByDescending(c => c.Trucks.Count)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
