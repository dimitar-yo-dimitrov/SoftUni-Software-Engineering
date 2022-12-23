using AutoMapper;

using FastFood.Models;
using FastFood.Services.Models.Categories;
using FastFood.Services.Models.Items;
using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Items;
using FastFood.Web.ViewModels.Positions;

namespace FastFood.Web.MappingConfiguration
{
    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(d => d.Name, mo => mo.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(d => d.Name, mo => mo.MapFrom(s => s.Name));

            //Categories
            this.CreateMap<CreateCategoryDto, Category>();
            this.CreateMap<CreateCategoryInputModel, CreateCategoryDto>()
                .ForMember(d => d.Name, mo => mo.MapFrom(s => s.CategoryName));
            this.CreateMap<Category, ListCategoryDto>();
            this.CreateMap<ListCategoryDto, CategoryAllViewModel>();

            //Items
            this.CreateMap<ListCategoryDto, CreateItemViewModel>()
                .ForMember(d => d.CategoryId, mo => mo.MapFrom(s => s.Id))
                .ForMember(d => d.CategoryName, mo => mo.MapFrom(s => s.Name));
            this.CreateMap<CreateItemInputModel, CreateItemDto>();
            this.CreateMap<CreateItemDto, Item>();
            this.CreateMap<Item, ListItemDto>()
                .ForMember(d => d.Category, mo => mo.MapFrom(s => s.Category.Name));
            this.CreateMap<ListItemDto, ItemsAllViewModels>();
        }
    }
}
