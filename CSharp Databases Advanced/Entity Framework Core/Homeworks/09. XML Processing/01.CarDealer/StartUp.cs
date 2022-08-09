using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        private static string _filePath;

        public static void Main(string[] args)
        {
            //Static because of Judge and use version less than 8.1.1 because with higher version doesn't work in main
            Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());
            CarDealerContext dbContext = new CarDealerContext();

            //Delete and create Database
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine($"A database has been created!");

            // Import:
            //InitializeDatasetFilePath("sales.xml");
            //string inputXml = File.ReadAllText(_filePath);
            //string xml = ImportSales(dbContext, inputXml);
            //Console.WriteLine(xml);

            // Export:
            InitializeOutputFilePath("cars.xml");
            string xml = GetCarsWithDistance(dbContext);
            File.WriteAllText(_filePath, xml);
        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitialiseMapper();

            string rootName = "Suppliers";
            ImportSupplierDto[] supplierDtos = Deserialize<ImportSupplierDto[]>(inputXml, rootName);

            ICollection<Supplier> validSuppliers = new List<Supplier>();

            foreach (var sDto in supplierDtos)
            {
                if (!IsValid(sDto))
                {
                    continue;
                }

                Supplier supplier = mapper.Map<Supplier>(sDto);
                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        // Problem 10 - Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            string rootName = "Parts";
            ImportPartDto[] partDtos = Deserialize<ImportPartDto[]>(inputXml, rootName);

            int[] supplierIds = context
                .Suppliers
                .Select(s => s.Id)
                .ToArray();

            IMapper mapper = InitialiseMapper();
            Part[] parts = mapper.Map<Part[]>(partDtos)
                .Where(p => supplierIds.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        // Problem 11 - Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            int[] partIds = context
                .Parts
                .Select(p => p.Id)
                .ToArray();

            string rootName = "Cars";
            ImportCarDto[] carDtos = Deserialize<ImportCarDto[]>(inputXml, rootName);

            Car[] cars = carDtos.Select(c => new Car
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance,
                PartCars = c.PartsIds
                    .Select(pc => pc.Id)
                    .Intersect(partIds)
                    .Distinct()
                    .Select(pc => new PartCar
                    {
                        PartId = pc
                    })
                    .ToArray()
            })
            .ToArray();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Length}";
        }

        // Problem 12 - Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string rootName = "Customers";
            ImportCustomerDto[] customerDtos = Deserialize<ImportCustomerDto[]>(inputXml, rootName);

            IMapper mapper = InitialiseMapper();
            Customer[] customers = mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        // Problem 13 - Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            int[] carIds = context
                .Cars
                .Select(c => c.Id)
                .ToArray();

            string rootName = "Sales";
            ImportSaleDto[] saleDtos = Deserialize<ImportSaleDto[]>(inputXml, rootName);

            IMapper mapper = InitialiseMapper();
            Sale[] sales = mapper.Map<Sale[]>(saleDtos)
                .Where(s => carIds.Contains(s.CarId))
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        // Problem 14 - Export Cars with Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            string rootName = "cars";
            IMapper mapper = InitialiseMapper();

            ExportCarWithDistanceDto[] carDtos = context
                .Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarWithDistanceDto>(mapper.ConfigurationProvider)
                .ToArray();

            return Serialize(carDtos, rootName);
        }

        // Problem 15 - Export Cars from Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            string rootName = "cars";
            IMapper mapper = InitialiseMapper();

            ExportCarBMWDto[] carDtos = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ProjectTo<ExportCarBMWDto>(mapper.ConfigurationProvider)
                .ToArray();

            return Serialize(carDtos, rootName);
        }

        // Problem 16 - Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            string rootName = "suppliers";
            IMapper mapper = InitialiseMapper();

            ExportSupplierDto[] supplierDtos = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportSupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            return Serialize(supplierDtos, rootName);
        }

        //Problem 17 - Export Cars with their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            string rootName = "cars";
            IMapper mapper = InitialiseMapper();

            ExportCarWithPartDto[] carDtos = context
                .Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarWithPartDto>(mapper.ConfigurationProvider)
                .ToArray();

            return Serialize(carDtos, rootName);
        }

        // Problem 18 - Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            string rootName = "customers";
            IMapper mapper = InitialiseMapper();

            ExportCustomerSaleDto[] customerDtos = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .ProjectTo<ExportCustomerSaleDto>(mapper.ConfigurationProvider)
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            return Serialize(customerDtos, rootName);
        }

        //Problem 19 - Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            string rootName = "sales";
            IMapper mapper = InitialiseMapper();

            ExportSaleWithDiscountDto[] saleDtos = context
                .Sales
                .ProjectTo<ExportSaleWithDiscountDto>(mapper.ConfigurationProvider)
                .ToArray();

            return Serialize(saleDtos, rootName);
        }

        //Helper methods
        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            var dtos = (T)xmlSerializer
                .Deserialize(reader);

            return dtos;
        }

        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
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

        private static IMapper InitialiseMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
                cfg.AddProfile<CarDealerProfile>());

            return config.CreateMapper();
        }
    }
}