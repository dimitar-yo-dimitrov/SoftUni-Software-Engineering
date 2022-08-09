using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string _filePath;

        public static void Main(string[] args)
        {
            //Static because of Judge
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));
            ProductShopContext dbContext = new ProductShopContext();

            //Delete and create Database
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine($"A database has been created!");

            // Import:
            //InitializeDatasetFilePath("categories-products.xml");
            //string inputXml = File.ReadAllText(_filePath);
            //string xml = ImportCategoryProducts(dbContext, inputXml);
            //Console.WriteLine(xml);

            // Export:
            InitializeOutputFilePath("users-and-products.xml");
            string xml = GetUsersWithProducts(dbContext);
            File.WriteAllText(_filePath, xml);
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            string rootName = "Users";
            ImportUserDto[] userDtos = Deserialize<ImportUserDto[]>(inputXml, rootName);

            ICollection<User> validUsers = new List<User>();

            foreach (ImportUserDto uDto in userDtos)
            {
                if (!IsValid(uDto))
                {
                    continue;
                }

                var user = Mapper.Map<User>(uDto);
                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitialiseMapper();

            string rootName = "Products";
            ImportProductDto[] productDtos = Deserialize<ImportProductDto[]>(inputXml, rootName);

            ICollection<Product> validProducts = new List<Product>();

            foreach (ImportProductDto pDto in productDtos)
            {
                if (!IsValid(pDto))
                {
                    continue;
                }

                Product product = mapper.Map<Product>(pDto);
                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitialiseMapper();

            string rootName = "Categories";
            ImportCategoryDto[] categoryDtos = Deserialize<ImportCategoryDto[]>(inputXml, rootName);

            ICollection<Category> validCategories = new List<Category>();

            foreach (ImportCategoryDto cDto in categoryDtos)
            {
                if (!IsValid(cDto))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(cDto);
                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitialiseMapper();

            string rootName = "CategoryProducts";
            ImportCategoryProductDto[] categoryProductDtos = Deserialize<ImportCategoryProductDto[]>(inputXml, rootName);

            ICollection<CategoryProduct> validCategoriesProducts = new List<CategoryProduct>();

            foreach (ImportCategoryProductDto cpDto in categoryProductDtos)
            {
                if (!IsValid(cpDto))
                {
                    continue;
                }

                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(cpDto);
                validCategoriesProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(validCategoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoriesProducts.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportProductInRangeDto[] products = context
                .Products
                .Where(p => p.Price > 499 && p.Price < 1001)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            string rootName = "Products";

            return Serialize(products, rootName);
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportUserWithSoldProductDto[] userDtos = context
                .Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<ExportUserWithSoldProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            string rootName = "Users";

            return Serialize(userDtos, rootName);
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IMapper mapper = InitialiseMapper();

            ExportCategoriesByProductsCountDto[] categoryProductDtos = context
                .Categories
                .ProjectTo<ExportCategoriesByProductsCountDto>(mapper.ConfigurationProvider)
                .OrderByDescending(cp => cp.NumberOfProducts)
                .ThenBy(cp => cp.TotalPriceSum)
                .ToArray();

            string rootName = "Categories";

            return Serialize(categoryProductDtos, rootName);
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            ExportUserWithProductsDto[] userDtos = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                //.ToArray() // Use this for the Judge
                .Select(u => new ExportUserWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsDto
                    {
                        ProductsCount = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .Select(p => new ExportProductInfoDto
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            ExportUserAndProductsDto userAndProductsInfo = new ExportUserAndProductsDto()
            {
                CountOfUsers = context
                    .Users
                    .Count(u => u.ProductsSold.Any()),

                Users = userDtos
            };

            string rootName = "Users";

            return Serialize(userAndProductsInfo, rootName);
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
                cfg.AddProfile<ProductShopProfile>());

            return config.CreateMapper();
        }
    }
}