using System.Linq;
using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(d => d.BuyerFullName,
                    mo => mo.MapFrom(s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));

            this.CreateMap<ExportProductInfoDto, ExportUserWithSoldProductDto>();
            this.CreateMap<User, ExportUserWithSoldProductDto>()
                .ForMember(d => d.SoldProducts,
                    mo => mo.MapFrom(s => s.ProductsSold));

            this.CreateMap<Category, ExportCategoriesByProductsCountDto>()
                .ForMember(d => d.NumberOfProducts,
                    mo => mo.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AveragePriceOfProducts,
                    mo => mo.MapFrom(s => s.CategoryProducts
                        .Average(p => p.Product.Price)))
                .ForMember(d => d.TotalPriceSum,
                    mo => mo.MapFrom(s => s.CategoryProducts
                        .Sum(p => p.Product.Price)));
        }
    }
}
