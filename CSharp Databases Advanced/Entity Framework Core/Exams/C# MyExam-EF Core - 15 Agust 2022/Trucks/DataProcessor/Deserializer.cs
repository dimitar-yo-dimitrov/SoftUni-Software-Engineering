namespace Trucks.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Artillery.DataProcessor.Helper;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootName = "Despatchers";

            ImportDespatchersDto[] despatcherDtos =
                ConvertXml.DeserializeXml<ImportDespatchersDto[]>(xmlString, rootName);

            var despatchers = new HashSet<Despatcher>();

            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher despatcher = new Despatcher
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                };

                var trucks = new List<Truck>();

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool validCategoryType = Enum
                        .TryParse<CategoryType>(truckDto.CategoryType.ToString(), out var categoryType);

                    if (!validCategoryType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool validMakeType = Enum
                        .TryParse<MakeType>(truckDto.MakeType.ToString(), out var makeType);

                    if (!validMakeType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    trucks.Add(new Truck
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = categoryType,
                        MakeType = makeType
                    });

                }

                despatcher.Trucks = trucks;
                despatchers.Add(despatcher);

                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, despatcherDto.Name, despatcher.Trucks.Count));
            }


            context.Despatchers.AddRange(despatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var clientDtos = JsonConvert.DeserializeObject<ImportClientWithTruckIdDto[]>(jsonString);

            ICollection<Client> clients = new List<Client>();

            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (clientDto.Type == "usual")
                {
                    continue;
                }

                Client client = new Client
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };

                var trucks = new List<ClientTruck>();

                foreach (var truckId in clientDto.Trucks.Distinct())
                {
                    Truck truck = context.Trucks
                        .FirstOrDefault(t => t.Id == truckId);

                    if (truck == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var clientTruck = new ClientTruck()
                    {
                        Client = client,
                        Truck = truck
                    };

                    trucks.Add(clientTruck);
                }

                client.ClientsTrucks = trucks;
                clients.Add(client);

                sb.AppendLine(String.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.Clients.AddRange(clients);
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
