using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static string _filePath;
        public static void Main(string[] args)
        {
            //Static because of Judge and use version less than 8.1.1 because with higher version doesn't work in main
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(CarDealerProfile)));
            CarDealerContext dbContext = new CarDealerContext();

            //Delete and create Database
            //dbContext.Database.EnsureCreated();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine($"A database has been created!");

            // Import:
            //InitializeDatasetFilePath("sales.json");
            //string inputJson = File.ReadAllText(_filePath);
            //string json = ImportSales(dbContext, inputJson);
            //Console.WriteLine(json);

            // Export:
            InitializeOutputFilePath("sales-discounts.json");
            string json = GetSalesWithAppliedDiscount(dbContext);
            File.WriteAllText(_filePath, json);
        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ImportSuppliersDto[] supplierDtos = JsonConvert
                .DeserializeObject<ImportSuppliersDto[]>(inputJson);

            ICollection<Supplier> validSuppliers = new List<Supplier>();

            foreach (var sDto in supplierDtos)
            {
                if (!IsValid(sDto))
                {
                    continue;
                }

                Supplier supplier = Mapper.Map<Supplier>(sDto);
                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}.";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            ImportPartDto[] partDtos = JsonConvert
                .DeserializeObject<ImportPartDto[]>(inputJson);

            ICollection<Part> validParts = new List<Part>();

            foreach (var pDto in partDtos)
            {
                bool validDto = context.Suppliers.Any(s => s.Id == pDto.SupplierId);

                if (!validDto)
                {
                    continue;
                }

                Part part = Mapper.Map<Part>(pDto);
                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            Car[] cars = new Car[carDtos.Length];

            for (int i = 0; i < carDtos.Length; i++)
            {
                Car newCar = new Car
                {
                    Make = carDtos[i].Make,
                    Model = carDtos[i].Model,
                    TravelledDistance = carDtos[i].TravelledDistance,
                };

                foreach (int partId in carDtos[i].PartsId.Distinct())
                {
                    newCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                cars[i] = newCar;
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ImportCustomerDto[] customerDtos = JsonConvert
                .DeserializeObject<ImportCustomerDto[]>(inputJson);

            ICollection<Customer> validCustomers = new List<Customer>();

            foreach (var cDto in customerDtos)
            {
                if (!IsValid(cDto))
                {
                    continue;
                }

                Customer customer = Mapper.Map<Customer>(cDto);
                validCustomers.Add(customer);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}.";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            List<ExportCustomerDto> customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver ? 1 : 0)
                .ProjectTo<ExportCustomerDto>()
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy",
            };

            string json = JsonConvert
                .SerializeObject(customers, Formatting.Indented, settings);

            return json;
        }

        //15. Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            List<ExportCarToyotaDto> cars = context
                .Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportCarToyotaDto>()
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {

            List<ExportLocalSupplierDto> localSuppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportLocalSupplierDto>()
                .ToList();

            return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
        }

        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars
                        .Select(cp => new
                        {
                            cp.Part.Name,
                            cp.Part.Price
                        })
                })
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        //18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert
                .SerializeObject(customers, Formatting.Indented, settings);
        }

        //19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSalesWithDiscountDto[] sales = context
                .Sales
                .ProjectTo<ExportSalesWithDiscountDto>()
                .Take(10)
                .ToArray();

            return JsonConvert
                .SerializeObject(sales, Formatting.Indented);
        }

        private static void InitializeDatasetFilePath(string fileName)
        {
            _filePath =
                Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/", fileName);
        }

        private static void InitializeOutputFilePath(string fileName)
        {
            _filePath =
                Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/", fileName);
        }

        /// <summary>
        /// Executes all validation attributes in a class and returns true or false depending on validation result.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            List<ValidationResult> validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}