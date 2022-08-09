using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using ProductShop.Data;
using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.User;
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
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            Console.WriteLine($"A database has been created!");

            // Import:
            InitializeDatasetFilePath("categories-products.json");
            string inputJson = File.ReadAllText(_filePath);
            string json = ImportCategoryProducts(dbContext, inputJson);
            Console.WriteLine(json);

            // Export:
            //InitializeOutputFilePath("users-and-products.json");
            //string json = GetUsersWithProducts(dbContext);
            //File.WriteAllText(_filePath, json);
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDto[] userDtos = JsonConvert
                .DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new List<User>();

            foreach (ImportUserDto uDto in userDtos)
            {
                if (!IsValid(uDto))
                {
                    continue;
                }

                User user = Mapper.Map<User>(uDto);
                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductDto[] productDtos = JsonConvert
                .DeserializeObject<ImportProductDto[]>(inputJson);

            ICollection<Product> validProducts = new List<Product>();

            foreach (ImportProductDto pDto in productDtos)
            {
                if (!IsValid(pDto))
                {
                    continue;
                }

                Product product = Mapper.Map<Product>(pDto);
                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ImportCategoryDto[] categoryDtos = JsonConvert
                .DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> validCategories = new List<Category>();

            foreach (var cDto in categoryDtos)
            {
                if (!IsValid(cDto))
                {
                    continue;
                }

                Category category = Mapper.Map<Category>(cDto);
                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoryProductDto[] categoryProductDtos = JsonConvert
                .DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> validCategoryProducts = new List<CategoryProduct>();

            foreach (var cpDto in categoryProductDtos)
            {
                if (!IsValid(cpDto))
                {
                    continue;
                }

                CategoryProduct categoryProduct = Mapper.Map<CategoryProduct>(cpDto);
                validCategoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductInRangeDto[] products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductInRangeDto>()
                .ToArray();

            string json = JsonConvert
                .SerializeObject(products, Formatting.Indented);

            return json;
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUserInfoWithSoldProductsDto[] users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUserInfoWithSoldProductsDto>()
                .ToArray();

            string json = JsonConvert
                .SerializeObject(users, Formatting.Indented);

            return json;
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts
                        .Count(cp => c.Id == cp.CategoryId),
                    AveragePrice = c.CategoryProducts
                        .Where(cp => c.Id == cp.CategoryId)
                        .Select(p => p.Product.Price)
                        .Average()
                        .ToString("f2"),
                    TotalRevenue = c.CategoryProducts
                        .Where(cp => c.Id == cp.CategoryId)
                        .Select(p => p.Product.Price)
                        .Sum()
                        .ToString("f2")
                })
                .OrderByDescending(p => p.ProductsCount)
                .ToList();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            string json = JsonConvert
                .SerializeObject(categories, Formatting.Indented);

            return json;
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .ToList() //For Judge
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold
                            .Count(product => product.Buyer != null),
                        Products = u.ProductsSold
                            .Where(product => product.Buyer != null)
                            .Select(p => new
                            {
                                p.Name,
                                p.Price
                            })
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToList();

            var result = new
            {
                UsersCount = users.Count,
                users
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            string json = JsonConvert
                .SerializeObject(result, Formatting.Indented, settings);

            return json;
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
