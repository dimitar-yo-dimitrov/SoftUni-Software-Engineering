using System.Linq;
using AutoMapper;

using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.User;
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
                .ForMember(d => d.SellerFullName, mo => mo
                    .MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            //Inner Dto
            this.CreateMap<Product, ExportUserSoldProductsDto>()
                .ForMember(d => d.BuyerFirstName, mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName, mo => mo.MapFrom(s => s.Buyer.LastName));
            //Outer Dto
            this.CreateMap<User, ExportUserInfoWithSoldProductsDto>()
                .ForMember(d => d.SoldProducts,
                    mo => mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));

        }
    }
}
